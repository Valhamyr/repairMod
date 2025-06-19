#!/usr/bin/env bash
set -euo pipefail

# Ensure setup has been run
if [ ! -d lib ]; then
    echo "Missing ./lib directory. Run ./setup.sh first." >&2
    exit 1
fi

cd RepairWorkbenchMod
dotnet build -c Release
