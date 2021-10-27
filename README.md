# Bone
directplay lobby project for jedi knight dark forces 2

## usage
_EXE download of version 0.000001 alpha is not available yet_

~~just download and run Bone.exe **as administrator** _(this is required for DirectPlay to launch JK)_~~

#### Run as Administrator
DirectPlay is old and fails to spawn JK.EXE unless its launcher is run as Administrator

### planned features
- directly host or join JK games via IP address
- automatic host->client transfer of map/patch
- patchcommander-like UI for mixing&matching patches
- global games list (probably hosted from bah.wtf)


### modules
- Bone.exe _(Bone: this is the application itself)_
- BoneRPlay.dll _(Bone RescindedPlay: this module interfaces with DirectPlay)_

### building
- change/setup ur inc/lib paths for a sufficiently-old directx _(locally compiled with dx5.2sdk; not included.. source it urself)_
- u MUST run visualstudio as Administrator,  then load the project  _(the admin priv crosses over to the debugged application)_


## credits
special thanks to:
- SM_Sith_Lord _(sharing insight)_
- shinyquagsire23 _(sharing insight)_
- RandomStarfighter _(sharing insight)_
- ZeqMacaw _(originating the DirectPlay efforts)_
- AcidRain _(originating the DirectPlay efforts)_

**AND EVERYBODY ELSE WHO SUPPORTS THE PROJECT!**
