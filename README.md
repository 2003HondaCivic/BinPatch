# BinPatch

BinPatch is a tool to create patches for executable files. Designed to make distributing patches easy.

Game patches & hacks 🎮, Software tweaks🪛, and more🏴‍☠️.

## Installation

Download pre-compiled binaries from [releases.](https://github.com/2003HondaCivic/BinPatch/releases)

## Building
Download the [source](https://github.com/2003HondaCivic/BinPatch/archive/refs/heads/master.zip) and build using Visual Studio 2022

## Usage - Patching

As simple as choosing the target file and the cooresponding .patch file and clicking patch. All files that are patched are saved as FileName.ext.bak

MD5 file hash is checked if the MD5 is provided in the .patch file. This is to ensure you patch the right file & version. To disable this comment out the MD5 section
```
MD5: 2f82623f9523c0d167862cad0eff6806 (with check) -> #MD5 2f82623f9523c0d167862cad0eff6806 (exclude check)
```
## Usage - Creating patches

Take the original binary and modified binary and put them into the cooresponding sections in the patch file generator, along with any other desired options. Click patch and "New Patch.patch" should be generated in the current working directory.

BinPatch was primarily made with [instruction patching](https://www.tripwire.com/state-of-security/ghidra-101-binary-patching) in mind (however it will work with any file). I prefer [Ghidra](https://github.com/NationalSecurityAgency/ghidra) or [x64dbg](https://x64dbg.com/) to patch binaries.

BinPatch needs creators to supply patches! Submit a pull request with your .patch files to have them publicly available [here](https://github.com/2003HondaCivic/BinPatch/tree/master/.patch%20files).


## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

## Attributions

Temporary icon from <a href="https://www.flaticon.com/free-icons/binary-code" title="binary code icons">Binary code icons created by Freepik - Flaticon</a>
