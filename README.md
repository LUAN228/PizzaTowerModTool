# PizzaTowerModTool

[![GitHub](https://img.shields.io/github/license/UnderminersTeam/UndertaleModTool?logo=github)](LICENSE.txt)

The most complete tool for modding, decompiling and unpacking Pizza Tower (and other GameMaker games!)

> *\* (Seeing a specialized modding tool built for maximum speed and pizza-fueled action...)*
> 
> *\* (IT'S PIZZA TIME!)*

# Quick Start

## Windows

1. Find the latest stable (or nightly) release from the [Downloads](#downloads) section below
2. Download the GUI version (e.g. `PizzaTowerModTool_v0.9.2.0-Windows.zip`), or the CLI version if you know what you're doing
3. Extract the ZIP file to a folder (do not run from inside the archive!)
4. Run `PizzaTowerModTool.exe` to start the tool
5. Open your game's data file (e.g. `data.win`, `game.ios`, `game.unx`, etc.) via File → Open

## macOS/Linux

As of writing, there is no official method of running PizzaTowerModTool's GUI on macOS or Linux natively. However, there are some options available:
- Use the CLI (command-line interface) version of the tool for automation and quick tasks.
- Run the tool via [Wine](https://winehq.org) or Proton on Linux/Steam Deck.

# Downloads

Both the latest stable and nightly releases can be compiled and downloaded directly via **GitHub Actions** in this repository!

PizzaTowerModTool has a few different versions to choose from:

* `GUI` (default) - the tool has a full graphical interface, making data file viewing and manipulation convenient.
* `CLI` - the tool is accessible only via a command-line interface, which is useful for automation and quick tasks.
* `Single file` - the tool is only one executable, with all dependencies embedded within it.
* `Non-single file` (default) - all dependencies are located right next to the executable.

# Main Features

* Optimized specifically for **Pizza Tower** bytecode, objects, sprites, and room setups, while maintaining compatibility with other GameMaker games.
* Can read every single byte from the data file and recreate a byte-for-byte exact copy from the decoded data.
* Properly handles all pointers in the file so adding/removing sprites, objects, or code won't corrupt your game.
* Includes an editor to adjust values, tilemaps, collisions, and levels.
* High-level GML decompiler and compiler for editing object logic, player states, and game mechanics.
* C# script runner for bulk importing/exporting sprites, animations, and GML code.

# Included Scripts

PizzaTowerModTool comes with a collection of C# scripts that extend its functionality for game modding.
For more information on them, consult the [SCRIPTS.md](SCRIPTS.md) file.

# Contributing

If you find a bug or a data file that does not load, please report it on the repository's Issues page.

# Compilation Instructions

In order to compile the repo yourself, the `.NET Core` SDK is required.

The following projects can be compiled:  
- `UndertaleModLib`: The core library used for GameMaker data files.
- `PizzaTowerModCli` / `UndertaleModCli`: Command line interface.
- `PizzaTowerModTool`: The main graphical user interface.

#### Compiling Via IDE
- Open `PizzaTowerModTool.sln` (or `UndertaleModTool.sln`) in Visual Studio, Rider, or VS Code.
- Select `PizzaTowerModTool` and build.

#### Compiling Via GitHub Actions (Recommended)
- Simply commit your changes to GitHub and let the automated **GitHub Actions** workflow build the executables under the **Actions -> Artifacts** tab!

# Credits & Acknowledgments

* Based on the original [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool) by the Underminers Team.
* Special thanks to Tour De Pizza for creating **Pizza Tower**!
