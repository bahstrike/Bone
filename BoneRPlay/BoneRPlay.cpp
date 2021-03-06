#include <Windows.h>
#include <comdef.h>
#include <initguid.h>
#include <stdio.h>
#include <stdarg.h>
#include <dplay.h>
#include <dplobby.h>



const char* FormatDPLAYRESULT(HRESULT hr);



// NEED TO RUN AS ADMINISTRATOR TO LAUNCH DPLAY LOBBY APPLICATION?  OTHERWISE WE GET  CANT CREATE PROCESS



// maybe need to do these to enable directplay?
//dism /Online /enable-feature /FeatureName:"LegacyComponents" /NoRestart
//dism /Online /enable-feature /FeatureName:"DirectPlay" /NoRestart


enum Result : int
{
	Success,
	NoDirectPlay,
	AppNotRegistered,
	CantCreateProcess,
	UnknownFailure,
};



//{BF0613C0-DE79-11D0-99C9-00A02476AD4B}
GUID GimmeJKGUID()
{
	static unsigned int _jkguid[] = {
		0x0BF0613C0,
		0x011D0DE79,
		0x0A000C999,
		0x04BAD7624
	};

	return *(GUID*)_jkguid;
}


BOOL FAR PASCAL DPlayEnumSessions(LPCDPSESSIONDESC2 pSrc, LPDWORD lpdwTimeOut, DWORD dwFlags, LPVOID lpContext)
{
	if (dwFlags & DPESC_TIMEDOUT)
		return FALSE;

	DPSESSIONDESC2* &pSession = *(DPSESSIONDESC2**)lpContext;
	pSession = new DPSESSIONDESC2;
	memcpy(pSession, pSrc, sizeof(DPSESSIONDESC2));

	if (pSrc->lpszSessionName != nullptr)
	{
		pSession->lpszSessionName = new wchar_t[256];
		wcscpy(pSession->lpszSessionName, pSrc->lpszSessionName);
	}

	return FALSE;// stop enumerating if we found one.. only support 1 session for query right now
}


extern "C"
{
	BOOL __stdcall QuerySession(const char* szAddress, const char* szPassword, GUID* pGuidInstance, int* pnMaxPlayers, int* pnCurPlayers, wchar_t* wcSessionName, DWORD* puUser1, DWORD* puUser2, DWORD* puUser3, DWORD* puUser4)
	{
		HRESULT hr;
		const char* szResult;
		IDirectPlay3* pDirectPlay = nullptr;

		hr = CoCreateInstance(CLSID_DirectPlay, NULL, CLSCTX_INPROC_SERVER, IID_IDirectPlay3, (LPVOID*)&pDirectPlay);
		if (FAILED(hr))
			return FALSE;


		IDirectPlayLobby2* pLobby = nullptr;
		hr = CoCreateInstance(CLSID_DirectPlayLobby, NULL, CLSCTX_INPROC_SERVER, IID_IDirectPlayLobby2, (LPVOID*)&pLobby);
		if (FAILED(hr))
		{
			pDirectPlay->Release();
			return FALSE;
		}

		char* addressConnection = nullptr;
		DWORD addressConnectionLen = 0;
		pLobby->CreateAddress(DPSPGUID_TCPIP, DPAID_INet, szAddress, strlen(szAddress) + 1, addressConnection, &addressConnectionLen);//query size

		addressConnection = new char[addressConnectionLen];
		pLobby->CreateAddress(DPSPGUID_TCPIP, DPAID_INet, szAddress, strlen(szAddress) + 1, addressConnection, &addressConnectionLen);


		pLobby->Release();
		pLobby = nullptr;


		hr = pDirectPlay->InitializeConnection(addressConnection, 0);
		delete[] addressConnection;

		szResult = FormatDPLAYRESULT(hr);

		if (FAILED(hr))
		{
			pDirectPlay->Release();
			return FALSE;
		}



		DPSESSIONDESC2 *pResultDesc = nullptr;



		DPSESSIONDESC2 sessionDesc;
		ZeroMemory(&sessionDesc, sizeof(DPSESSIONDESC2));
		sessionDesc.dwSize = sizeof(DPSESSIONDESC2);
		sessionDesc.guidApplication = GimmeJKGUID();
		wchar_t password[128];
		if (szPassword != nullptr && szPassword[0] != 0)
		{
			int slen = strlen(szPassword);
			mbstowcs(password, szPassword, slen);
			password[slen] = 0;

			sessionDesc.lpszPassword = password;
		}
		hr = pDirectPlay->EnumSessions(&sessionDesc, 0, DPlayEnumSessions, &pResultDesc, DPENUMSESSIONS_AVAILABLE);

		szResult = FormatDPLAYRESULT(hr);

		pDirectPlay->Release();


		if (FAILED(hr) || pResultDesc == nullptr)
			return FALSE;


		*pGuidInstance = pResultDesc->guidInstance;
		*pnMaxPlayers = pResultDesc->dwMaxPlayers;
		*pnCurPlayers = pResultDesc->dwCurrentPlayers;
		if (pResultDesc->lpszSessionName == nullptr)
			wcscpy(wcSessionName, L"");
		else
			wcscpy(wcSessionName, pResultDesc->lpszSessionName);
		*puUser1 = pResultDesc->dwUser1;
		*puUser2 = pResultDesc->dwUser2;
		*puUser3 = pResultDesc->dwUser3;
		*puUser4 = pResultDesc->dwUser4;



		if (pResultDesc->lpszSessionName != nullptr)
			delete[] pResultDesc->lpszSessionName;

		delete pResultDesc;
		pResultDesc = nullptr;

		return TRUE;
	}


	static char s_szBlank[1] = { 0 };

	IDirectPlayLobby2A* g_pLobby = nullptr;
	DWORD g_uAppID = 0;

	void __stdcall Shutdown()
	{
		if (g_pLobby != nullptr)
		{
			g_pLobby->Release();
			g_pLobby = nullptr;
		}

		g_uAppID = 0;
	}

	Result __stdcall Host()
	{
		Shutdown();

		HRESULT hr;

		hr = CoCreateInstance(CLSID_DirectPlayLobby, NULL, CLSCTX_INPROC_SERVER, IID_IDirectPlayLobby2A, (LPVOID*)&g_pLobby);
		if (FAILED(hr))
			return Result::NoDirectPlay;

		DPSESSIONDESC2 sessionDesc;
		ZeroMemory(&sessionDesc, sizeof(DPSESSIONDESC2));
		sessionDesc.dwSize = sizeof(DPSESSIONDESC2);
		sessionDesc.guidApplication = GimmeJKGUID();
		CoCreateGuid(&sessionDesc.guidInstance);

		DPNAME playerName;
		ZeroMemory(&playerName, sizeof(DPNAME));
		playerName.dwSize = sizeof(DPNAME);
		playerName.lpszShortNameA = s_szBlank;

		DPLCONNECTION connectInfo;
		ZeroMemory(&connectInfo, sizeof(DPLCONNECTION));
		connectInfo.dwSize = sizeof(DPLCONNECTION);
		connectInfo.dwFlags = DPLCONNECTION_CREATESESSION;
		connectInfo.guidSP = DPSPGUID_TCPIP;
		connectInfo.lpPlayerName = &playerName;
		connectInfo.lpSessionDesc = &sessionDesc;

		hr = g_pLobby->RunApplication(0, &g_uAppID, &connectInfo, NULL);

		if (hr != DP_OK)
		{
			g_pLobby->Release();
			g_pLobby = nullptr;

			if (hr == DPERR_UNKNOWNAPPLICATION)
				return Result::AppNotRegistered;

			if (hr == DPERR_CANTCREATEPROCESS)
				return Result::CantCreateProcess;

			return Result::UnknownFailure;
		}

		return Result::Success;
	}

	Result __stdcall Join(const GUID* pInstanceGUID, const char* szAddress, const char* szPassword)
	{
		Shutdown();

		HRESULT hr;

		hr = CoCreateInstance(CLSID_DirectPlayLobby, NULL, CLSCTX_INPROC_SERVER, IID_IDirectPlayLobby2A, (LPVOID*)&g_pLobby);
		if (FAILED(hr))
			return Result::NoDirectPlay;

		char* addressConnection = nullptr;
		DWORD addressConnectionLen = 0;
		g_pLobby->CreateAddress(DPSPGUID_TCPIP, DPAID_INet, szAddress, strlen(szAddress) + 1, addressConnection, &addressConnectionLen);//query size

		addressConnection = new char[addressConnectionLen];
		g_pLobby->CreateAddress(DPSPGUID_TCPIP, DPAID_INet, szAddress, strlen(szAddress) + 1, addressConnection, &addressConnectionLen);


		DPSESSIONDESC2 sessionDesc;
		ZeroMemory(&sessionDesc, sizeof(DPSESSIONDESC2));
		sessionDesc.dwSize = sizeof(DPSESSIONDESC2);
		sessionDesc.guidApplication = GimmeJKGUID();
		sessionDesc.guidInstance = *pInstanceGUID;
		sessionDesc.lpszSessionNameA = s_szBlank;
		wchar_t password[128];
		if (szPassword != nullptr && szPassword[0] != 0)
		{
			int slen = strlen(szPassword);
			mbstowcs(password, szPassword, slen);
			password[slen] = 0;

			sessionDesc.lpszPassword = password;
		}

		DPNAME playerName;
		ZeroMemory(&playerName, sizeof(DPNAME));
		playerName.dwSize = sizeof(DPNAME);
		playerName.lpszShortNameA = s_szBlank;

		DPLCONNECTION connectInfo;
		ZeroMemory(&connectInfo, sizeof(DPLCONNECTION));
		connectInfo.dwSize = sizeof(DPLCONNECTION);
		connectInfo.lpSessionDesc = &sessionDesc;
		connectInfo.lpPlayerName = &playerName;
		connectInfo.guidSP = DPSPGUID_TCPIP;
		connectInfo.lpAddress = addressConnection;
		connectInfo.dwAddressSize = addressConnectionLen;
		connectInfo.dwFlags = DPLCONNECTION_JOINSESSION;

		hr = g_pLobby->RunApplication(0, &g_uAppID, &connectInfo, NULL);
		delete[] addressConnection;

		if (hr != DP_OK)
		{
			g_pLobby->Release();
			g_pLobby = nullptr;

			if (hr == DPERR_UNKNOWNAPPLICATION)
				return Result::AppNotRegistered;

			if (hr == DPERR_CANTCREATEPROCESS)
				return Result::CantCreateProcess;

			return Result::UnknownFailure;
		}

		return Result::Success;
	}

	BOOL __stdcall HasGameExited()
	{
		if (g_pLobby == nullptr)
			return TRUE;

		DWORD messageFlags = DPLMSG_SYSTEM;
		int message[1024];
		DWORD messageSize = sizeof(message);

		HRESULT hr = g_pLobby->ReceiveLobbyMessage(0, g_uAppID, &messageFlags, &message, &messageSize);

		// if no messages, game still running
		if (hr == DPERR_NOMESSAGES)
			return FALSE;

		// if error, game is not running
		if (hr != DP_OK)
			return TRUE;


		// ignore if not system message
		if ((messageFlags & DPLMSG_SYSTEM) == 0)
			return FALSE;

		int code = *(int*)message;//dwType,guidInstance

		// if exit code, we're done
		if (code == 4)
			return TRUE;


		// ignore anything else
		return FALSE;
	}


	void __stdcall test()
	{
		MessageBox(0, "blahlalh", 0, 0);


#if 0
		GUID guidInstance;
		int maxPlayers, curPlayers;
		wchar_t sessionName[512];
		DWORD user1, user2, user3, user4;
		QuerySession("192.168.5.3", nullptr, &guidInstance, &maxPlayers, &curPlayers, sessionName, &user1, &user2, &user3, &user4);
#elif 1
		Host();
#else

		GUID instance = GimmeInstanceGUID();

		Join(&instance, "192.168.5.3");
#endif


		while (!HasGameExited())
			Sleep(100);
	}





}



BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpReserved)
{
	switch (fdwReason)
	{
	case DLL_PROCESS_ATTACH:
		CoInitialize(NULL);
		break;

	case DLL_PROCESS_DETACH:
		Shutdown();

		CoUninitialize();
		break;
	}

	return TRUE;
}




// super unsafe esp for threads but im lazy
const char* FormatHRESULT(HRESULT hr)
{
	_com_error err(hr);
	LPCTSTR errMsg = err.ErrorMessage();

	static char szBuf[1024];
	strncpy(szBuf, errMsg, sizeof(szBuf) - 1);

	return szBuf;//lol
}

const char* FormatDPLAYRESULT(HRESULT hr)
{
	switch (hr)
	{
	case S_OK: return "DP_OK";
	case MAKE_DPHRESULT(5): return "DPERR_ALREADYINITIALIZED";
	case MAKE_DPHRESULT(10):return "DPERR_ACCESSDENIED";
	case MAKE_DPHRESULT(20):return "DPERR_ACTIVEPLAYERS";
	case MAKE_DPHRESULT(30):return "DPERR_BUFFERTOOSMALL";
	case MAKE_DPHRESULT(40):return "DPERR_CANTADDPLAYER";
	case MAKE_DPHRESULT(50):return "DPERR_CANTCREATEGROUP";
	case MAKE_DPHRESULT(60):return "DPERR_CANTCREATEPLAYER";
	case MAKE_DPHRESULT(70):return "DPERR_CANTCREATESESSION";
	case MAKE_DPHRESULT(80):return "DPERR_CAPSNOTAVAILABLEYET";
	case MAKE_DPHRESULT(90):return "DPERR_EXCEPTION";
	case E_FAIL:return "DPERR_GENERIC";
	case MAKE_DPHRESULT(120):return "DPERR_INVALIDFLAGS";
	case MAKE_DPHRESULT(130):return "DPERR_INVALIDOBJECT";
		//case E_INVALIDARG:return "DPERR_INVALIDPARAM";
	case DPERR_INVALIDPARAM:return "DPERR_INVALIDPARAMS";
	case MAKE_DPHRESULT(150):return "DPERR_INVALIDPLAYER";
	case MAKE_DPHRESULT(155):return "DPERR_INVALIDGROUP";
	case MAKE_DPHRESULT(160):return "DPERR_NOCAPS";
	case MAKE_DPHRESULT(170):return "DPERR_NOCONNECTION";
		//case E_OUTOFMEMORY:return "DPERR_NOMEMORY";
	case DPERR_NOMEMORY:return "DPERR_OUTOFMEMORY";
	case MAKE_DPHRESULT(190):return "DPERR_NOMESSAGES";
	case MAKE_DPHRESULT(200):return "DPERR_NONAMESERVERFOUND";
	case MAKE_DPHRESULT(210):return "DPERR_NOPLAYERS";
	case MAKE_DPHRESULT(220):return "DPERR_NOSESSIONS";
	case E_PENDING:return "DPERR_PENDING";
	case MAKE_DPHRESULT(230):return "DPERR_SENDTOOBIG";
	case MAKE_DPHRESULT(240):return "DPERR_TIMEOUT";
	case MAKE_DPHRESULT(250):return "DPERR_UNAVAILABLE";
	case E_NOTIMPL:return "DPERR_UNSUPPORTED";
	case MAKE_DPHRESULT(270):return "DPERR_BUSY";
	case MAKE_DPHRESULT(280):return "DPERR_USERCANCEL";
	case E_NOINTERFACE:return "DPERR_NOINTERFACE";
	case MAKE_DPHRESULT(290):return "DPERR_CANNOTCREATESERVER";
	case MAKE_DPHRESULT(300):return "DPERR_PLAYERLOST";
	case MAKE_DPHRESULT(310):return "DPERR_SESSIONLOST";
	case MAKE_DPHRESULT(320):return "DPERR_UNINITIALIZED";
	case MAKE_DPHRESULT(330):return "DPERR_NONEWPLAYERS";
	case MAKE_DPHRESULT(340):return "DPERR_INVALIDPASSWORD";
	case MAKE_DPHRESULT(350):return "DPERR_CONNECTING";
	case MAKE_DPHRESULT(1000):return "DPERR_BUFFERTOOLARGE";
	case MAKE_DPHRESULT(1010):return "DPERR_CANTCREATEPROCESS";
	case MAKE_DPHRESULT(1020):return "DPERR_APPNOTSTARTED";
	case MAKE_DPHRESULT(1030):return "DPERR_INVALIDINTERFACE";
	case MAKE_DPHRESULT(1040):return "DPERR_NOSERVICEPROVIDER";
	case MAKE_DPHRESULT(1050):return "DPERR_UNKNOWNAPPLICATION";
	case MAKE_DPHRESULT(1070):return "DPERR_NOTLOBBIED";
	case MAKE_DPHRESULT(1080):return "DPERR_SERVICEPROVIDERLOADED";
	case MAKE_DPHRESULT(1090):return "DPERR_ALREADYREGISTERED";
	case MAKE_DPHRESULT(1100):return "DPERR_NOTREGISTERED";
	case MAKE_DPHRESULT(2000):return "DPERR_AUTHENTICATIONFAILED";
	case MAKE_DPHRESULT(2010):return "DPERR_CANTLOADSSPI";
	case MAKE_DPHRESULT(2020):return "DPERR_ENCRYPTIONFAILED";
	case MAKE_DPHRESULT(2030):return "DPERR_SIGNFAILED";
	case MAKE_DPHRESULT(2040):return "DPERR_CANTLOADSECURITYPACKAGE";
	case MAKE_DPHRESULT(2050):return "DPERR_ENCRYPTIONNOTSUPPORTED";
	case MAKE_DPHRESULT(2060):return "DPERR_CANTLOADCAPI";
	case MAKE_DPHRESULT(2070):return "DPERR_NOTLOGGEDIN";
	case MAKE_DPHRESULT(2080):return "DPERR_LOGONDENIED";

	default: return FormatHRESULT(hr);
	}
}