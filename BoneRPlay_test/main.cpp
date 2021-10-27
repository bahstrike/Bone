#include <Windows.h>

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, LPSTR, int)
{
	HMODULE hDLL = LoadLibrary("BoneRPlay.dll");

	((void(__stdcall*)())GetProcAddress(hDLL, "test"))();

	FreeLibrary(hDLL);

	return 0;
}