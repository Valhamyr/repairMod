#!/usr/bin/env bash

# Setup script for RepairWorkbenchMod development
set -euo pipefail

# Ensure dotnet SDK 8.0 is installed
if ! command -v dotnet >/dev/null 2>&1; then
    echo "Installing dotnet-sdk-8.0"
    sudo apt-get update
    sudo apt-get install -y dotnet-sdk-8.0
fi

echo "dotnet SDK version: $(dotnet --version)"

echo "Checking Vintage Story installation path via \$VINTAGE_STORY"

if [ -z "${VINTAGE_STORY:-}" ]; then
    echo "Please export VINTAGE_STORY pointing to your Vintage Story game directory."
    echo "Example: export VINTAGE_STORY=/path/to/VintageStory"
    exit 1
fi

mkdir -p lib
# copy necessary libraries for compilation
for dll in VintagestoryAPI.dll VintagestoryLib.dll OpenTK.dll; do
    if [ ! -f "lib/$dll" ]; then
        if [ -f "$VINTAGE_STORY/$dll" ]; then
            cp "$VINTAGE_STORY/$dll" lib/
        else
            echo "Missing $dll in $VINTAGE_STORY"
            exit 1
        fi
    fi
done

echo "Libraries copied to ./lib"

echo "Environment setup complete"
