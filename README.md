# Bone
directplay lobby project for jedi knight dark forces 2

## usage
_EXE download of version 0.000001 alpha is not available yet_

~~just download and run Bone.exe **as administrator** _(this is required for DirectPlay to launch JK)_~~

### planned features
- directly host or join JK games via IP address
- automatic host->client transfer of map/patch
- patchcommander-like UI for mixing&matching patches
- global games list (probably hosted from bah.wtf)


### modules
- Bone.exe _(Bone: this is the application itself)_
- BoneRPlay.dll _(Bone RescindedPlay: this module interfaces with DirectPlay)_
- BoneRPlay_test.exe _(Bone RescindedPlay_test: for development; convenient EXE for launching test function in BoneRPlay.dll)_
- 

### building
- change/setup ur inc/lib paths for directx (locally compiled with dx5.2sdk; not included.. source it urself)
- u MUST run visualstudio as Administrator,  then load the project;  the admin priv crosses over to the debugged application


## credits
special thanks to:
- SM_Sith_Lord _(sharing insight)_
- shinyquagsire23 _(sharing insight)_
- RandomStarfighter _(sharing insight)_
- ZeqMacaw _(originating the DirectPlay efforts)_
- AcidRain _(originating the DirectPlay efforts)_

**AND EVERYBODY ELSE WHO SUPPORTS THE PROJECT!**
