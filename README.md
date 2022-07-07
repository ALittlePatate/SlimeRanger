# SlimeRanger

This is a cheat for the game Slime Rancher, since the 2nd one has been announced i am very hyped so i made this in a day, i will probably push updates to add stuff.
This uses [BepInEx](https://github.com/BepInEx/BepInEx).

## Features
* An IMGUI menu thanks to UnityEngine
* Reveal map
* Godmode
* Add a slime key
* Get all the upgrades
* Set your energy between 0 and 1000
* Set your health between 0 and 1000
* Set your money between 0 and 1000
* Makes you resistant to the radiations
* Infinite energy
* Fly (+ fly speed slider). This temporarily disables the jetpack to use space to fly. (uses AZERTY keybinds, I will update this with your ingame keybinds)
* Save your position
* Teleport to your saved position

## Installation

0. [Build the cheat from source](https://github.com/ALittlePatate/SlimeRanger#building-from-source).
1. Put the SlimeRanger.dll (located in `SlimeRanger\bin\Release\net46`) file inside `C:\Program Files (x86)\Steam\steamapps\common\Slime Rancher\BepInEx\plugins` folder.
2. Start the game, now you have successfully installed SlimeRanger. Use INSERT to open the menu

## Uninstallation

0. Delete the folder `BepInEx`, and the files `winhttp.dll`, `changelog.txt` and `doorstop_config.ini` from `C:\Program Files (x86)\Steam\steamapps\common\Slime Rancher`

## Building from source

0. Clone the repository
1. Download [a BE build of BepInEx](https://builds.bepinex.dev/projects/bepinex_be).
2. Extract all the files from `BepInEx_UnityMono_x64_*******_*.*.*-be.***.zip` to `C:\Program Files (x86)\Steam\steamapps\common\Slime Rancher`
3. Start your game. BepInEx will generate useful stuff. Wait a bit then close the game.
4. Open the .sln file of SlimeRanger in Visual Studio (i used VS2022).
5. Go to : Project --> Add a reference --> Browse --> Click on the browse button in the down right corner of the window.
6. Add those files :
* `C:\Program Files (x86)\Steam\steamapps\common\Slime Rancher\SlimeRancher_Data\Managed\Assembly-CSharp.dll`
* `C:\Program Files (x86)\Steam\steamapps\common\Slime Rancher\SlimeRancher_Data\Managed\UnityEngine.UI`
7. Build the solutions in Release | Any CPU mode

## Contact

You can add me on discord at patate#1252

## Code used

For teaching me the basics :
* [A Begginner's Guide To Hacking Unity Games](https://www.unknowncheats.me/wiki/A_Beginner%27s_Guide_To_Hacking_Unity_Games)

For teaching me how to make a mod using BepInEx :
* [BepInEx docs](https://docs.bepinex.dev/master/articles/dev_guide/plugin_tutorial/index.html)

For teaching me about the UnityEngine API :
* [Unity User Manual 2020.3 (LTS)](https://docs.unity3d.com/Manual/index.html)

For decompiling and looking in the source code of the game :
* [dnSpy : a .NET debugger and assembly editor](https://github.com/dnSpy/dnSpy)

## Contributing

Open an [issue](https://github.com/ALittlePatate/SlimeRanger/issues/new) or make a [pull request](https://github.com/ALittlePatate/SlimeRanger/pulls), i'll be glad to improve my project with you !

## License

[GPL 3.0](https://www.gnu.org/licenses/gpl-3.0.md)
