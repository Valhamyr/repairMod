# Repair Workbench Mod

This repository contains a small example mod for Vintage Story. The `RepairWorkbenchMod backup 7 last broken version before butchery structure` directory holds the source code and assets. Use the provided scripts to set up a build environment.

## Quick Start

1. Install the required .NET SDK and copy game libraries:

```bash
./setup.sh
```

`setup.sh` expects the environment variable `VINTAGE_STORY` to point to your Vintage Story installation (where `VintagestoryAPI.dll` resides).

2. Build the mod:

```bash
cd 'RepairWorkbenchMod backup 7 last broken version before butchery structure'
dotnet build -c Release
```

The resulting DLL will be in `bin/Release/net7.0`.
