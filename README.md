# BetterSabotage
![GitHub](https://img.shields.io/github/license/Pandraghon/BetterSabotage)
![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/Pandraghon/BetterSabotage?include_prereleases)
![GitHub all releases](https://img.shields.io/github/downloads/Pandraghon/BetterSabotage/total)

BetterSabotage is an Among Us mod. Its purpose is to add functionality to sabotages.

For the moment, only the Steam version (2021.3.5s) of the game is supported.

## Features

 - **Sabotage Comms** makes everyone **anonymous**.
   Everyone is gray, without skin, hat or pet.
   - Options: [ `Nobody` | `Crewmates` | `Everyone` ]
     - `Nobody`: disable this feature
     - `Crewmates`: only Crewmates are impacted. Impostors' vision remains unchanged
     - `Everyone`: even Impostors are impacted
 - **Sabotage Reactor** makes the player's camera **shake**.
   - Options: [ `None` | `Low` | `High` ]
     - `None`: disable this feature
     - `Low`: the shakes are mild
     - `High`: the shakes are strong  
    
## Extra features

 - **Map Selection** and **# Impostors** options are available in Online Lobby

## Installation

Everyone in the lobby need to have the mod installed.  
Follow one of these methods to install it:

 - [All included Archive](#all-included-archive): easiest
 - [Custom Install](#custom-install): advanced (recommended)

### All included Archive

 1. Download the file `BetterSabotage-vX.X.X.zip` in the [Releases section](https://github.com/Pandraghon/BetterSabotage/releases).
 2. Extract the content of the zip into your game folder (i.e. `Steam\steamapps\common\Among Us`).
 3. Run the game

### Custom Install

 1. Install Reactor BepInEx by following **[these instructions](https://docs.reactor.gg/docs/basic/install_bepinex/)**.
 2. Install Reactor by following **[these instructions](https://docs.reactor.gg/docs/basic/install_reactor)**.
 3. Download the file `BetterSabotage-2021.3.5s.dll` in the [Releases section](https://github.com/Pandraghon/BetterSabotage/releases).
 4. Copy the dll file into `Among Us/BepInEx/plugins`.
 5. Repeat steps 3-4 for the file `Essentials-2021.3.5s.dll` from [DorCoMaNdO's repository](https://github.com/DorCoMaNdO/Reactor-Essentials/releases).
 6. (Optional) If you want to play on official servers, you must do the following :
    - Open **`Among us/BepInEx/config/gg.reactor.api.cfg`** with a text editor. 
    - Find the line `Modded handshake = true` and change it to `Modded handshake = false`.
    - Save and close your editor.

## Uninstallation

### Only Remove BetterSabotage

To uninstall BetterSabotage, simply delete `BetterSabotage-2021.3.5s.dll` from `Among Us/BepInEx/plugins`.

### Factory Reset

Remove following files and folders from the Among Us folder:

```
├── BepInEx/
├── mono/
├── doorstop_config.ini
└── winhttp.dll
```

## Used libraries

 - ![](https://img.shields.io/github/stars/NuclearPowered/Reactor?style=social) https://github.com/NuclearPowered/Reactor: Modding api for Among Us
 - ![](https://img.shields.io/github/stars/DorCoMaNdO/Reactor-Essentials?style=social) https://github.com/DorCoMaNdO/Reactor-Essentials: A library with essential tools to make plugins user-friendly to configure and use and to speed up development.
 - ![](https://img.shields.io/github/stars/NuclearPowered/BepInEx?style=social) https://github.com/NuclearPowered/BepInEx (forked from https://github.com/BepInEx/BepInEx): Unity / XNA game patcher and plugin framework 
 - ![](https://img.shields.io/github/stars/BepInEx/HarmonyX?style=social) https://github.com/BepInEx/HarmonyX: A library for patching, replacing and decorating .NET and Mono methods during runtime. 

## License

This software is distributed under the [MIT License](https://github.com/Pandraghon/BetterSabotage/blob/master/LICENSE).
