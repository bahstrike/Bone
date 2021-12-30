# Bone
directplay lobby project for jedi knight dark forces 2

## usage

just download and run Bone.exe **as administrator** _(this is required for DirectPlay to launch JK)_

**STATUS: this project is broken cuz of progressive deprecations of old MS APIs.. it works for like 2 PCs on the planet and seemingly nobody else.  we'll try to find a solution, but it is not known at the moment.**  still works to query JK game details at a target IP address;  but probably wont launch JK.EXE for you via DirectPlay, thus automatically into a network session :(

---

## details

### features
- directly host or join JK games via IP address

### planned features
- automatic host->client transfer of map/patch
- patchcommander-like UI for mixing&matching patches
- global games list

---

## development

### modules
- Bone.exe _(**Bone** (Bone): this is the application itself)_
- BoneRPlay.dll _(**Bone RescindedPlay** (BoneRPlay): this module interfaces with DirectPlay)_

### building
- change/setup ur inc/lib paths for a sufficiently-old directx _(locally compiled with dx5.2sdk; not included.. source it urself)_
- u MUST run visualstudio as Administrator,  then load the project  _(the admin priv crosses over to the debugged application)_

---

## credits
special thanks to:
- SM_Sith_Lord _(sharing insight)_
- shinyquagsire23 _(sharing insight)_
- RandomStarfighter _(sharing insight)_
- ZeqMacaw _(originating the DirectPlay efforts)_
- AcidRain _(originating the DirectPlay efforts)_

**AND EVERYBODY ELSE WHO SUPPORTS THE PROJECT!**
