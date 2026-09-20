# PizzaTowerModTool
[![GitHub](https://img.shields.io/github/license/SEU_USUARIO/PizzaTowerModTool?logo=github)](https://github.com/SEU_USUARIO/PizzaTowerModTool/blob/master/LICENSE.txt)
The most complete tool for modding, decompiling and unpacking Pizza Tower (and other GameMaker games!)
> *\* (It's time to show what you're made of!)*
# Quick Start
## Windows
1. Find the latest release from the [Downloads](#downloads) section below.
2. Download the GUI version (e.g., `PizzaTowerModTool_v0.9.2.0-Windows.zip`).
3. Extract the ZIP file to a folder (do not run from inside the archive!).
4. Run `PizzaTowerModTool.exe` to start the tool.
5. Open your game's data file (e.g. `data.win`, `game.unx`, etc.) via File → Open.
## macOS & Linux
*Note: macOS and Linux are currently not supported.*
# Downloads
Both stable and development releases can be downloaded from the table below!

| Release | Link / Status |
| :--- | :--- |
| Latest | [![Latest Release](https://img.shields.io/github/v/release/SEU_USUARIO/PizzaTowerModTool)](https://github.com/SEU_USUARIO/PizzaTowerModTool/releases) |

PizzaTowerModTool comes in the following options:
* `GUI` - The full graphical interface, making data file viewing and manipulation convenient.
* `Non-single file` (default) - All dependencies are located next to the executable for maximum stability.
* `Single file` - The tool is bundled into one executable with all dependencies embedded.
# Main Features
* Can read every single byte from the data file of Pizza Tower and most other GameMaker games, then recreate an exact copy from the decoded data.
* Properly handles all pointers in the file so that adding, removing, or tweaking elements won't break the file format.
* Includes a full graphical editor to inspect and edit code, objects, sprites, textures, and sounds.
* Built-in room/level editor.
* High-level GML decompiler and compiler to edit game logic natively.
* Full support for running C# (`.csx`) scripts to automate repetitive modding tasks and sprite batching.
* Automatic file associations for GameMaker data files.
# Included Scripts
PizzaTowerModTool comes with a collection of C# scripts that extend its functionality for game modding.
For more information, consult the [SCRIPTS.md](https://github.com/SEU_USUARIO/PizzaTowerModTool/blob/master/SCRIPTS.md) file.
# Contributing
If you find a bug or a data file that does not load, please report it on the [issues page](https://github.com/SEU_USUARIO/PizzaTowerModTool/issues).
# Compilation Instructions
In order to compile the repo yourself, the `.NET Core SDK` is required.
When cloning using Git, make sure to recursively clone submodules (e.g. with `--recurse-submodules`).
The following projects can be compiled:  
- `UndertaleModLib`: The core library used by the project.
- `PizzaTowerModTool`: The main graphical user interface for interacting with GameMaker data files.
#### Compiling Via IDE
- Open `PizzaTowerModTool.sln` in your IDE of choice (Visual Studio, JetBrains Rider, Visual Studio Code, etc.).
- Select the `PizzaTowerModTool` project.
- Build / Compile.
#### Compiling Via Command Line
- Open a terminal and navigate to the directory of `PizzaTowerModTool.sln`.
- Execute `dotnet publish PizzaTowerModTool`.
# Special thanks
Special thanks to the **Underminers Team** for creating the original UndertaleModTool framework upon which this tool is built, and to **Tour De Pizza** for creating Pizza Tower!
