# Repair Mod TODO

## Current State
- The only code exists in `RepairWorkbenchMod backup 7 last broken version before butchery structure.zip`. Inside the archive the core classes are empty stubs:
  - `BlockRepairBench` derives from `Block` but has no logic.
  - `BlockEntityRepairBench` derives from `BlockEntity` but is empty.
  - `ItemRepairHammer` derives from `Item` without functionality.
- Game logs reveal missing assets and recipe problems:
  - Client log warns about missing shape `game:shapes/block/cube.json` and missing texture `game:textures/block/wood/planks/copper.png` for the copper bench variant.
  - Server log shows `GridRecipe.ResolveIngredients` null reference errors during `AssetsLoaded`.

## Tasks
1. **Done** – Reintroduced iron and steel bench variants and added corresponding assets and recipes.
2. **Done** – Implemented basic functionality for `BlockRepairBench`, `BlockEntityRepairBench` and `ItemRepairHammer` so tools can be repaired using nuggets.
3. **Done** – Added missing shapes and textures to silence log warnings.
4. Review the structure of `butchering_1.9.0.zip` for working multiblock examples and replicate the approach.
5. Add nugget count visuals in the bowl and durability feedback on the tool.
6. **Done** – Bumped `modinfo.json` version after updating recipes and assets.
