
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;

namespace RepairWorkbench
{
    public class BlockEntityRepairBench : BlockEntity
    {
        private InventoryGeneric inventory;

        public ItemSlot ToolSlot => inventory[0];
        public ItemSlot NuggetSlot => inventory[1];

        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);
            inventory ??= new InventoryGeneric(2, "repairbench-" + Pos.ToShortString(), api);
            inventory.LateInitialize("repairbench-" + Pos.X + "/" + Pos.Y + "/" + Pos.Z, api);
        }

        public bool OnInteract(IPlayer player)
        {
            ItemSlot activeSlot = player.InventoryManager.ActiveHotbarSlot;

            if (!activeSlot.Empty)
            {
                if (ToolSlot.Empty)
                {
                    int moved = activeSlot.TryPutInto(Api.World, ToolSlot, 1);
                    if (moved > 0) { MarkDirty(true); return true; }
                }
                else if (NuggetSlot.Empty || activeSlot.Itemstack.Equals(Api.World, NuggetSlot.Itemstack, GlobalConstants.IgnoredStackAttributes))
                {
                    int moved = activeSlot.TryPutInto(Api.World, NuggetSlot, 1);
                    if (moved > 0) { MarkDirty(true); return true; }
                }
            }
            else
            {
                if (!ToolSlot.Empty)
                {
                    ItemStack stack = ToolSlot.TakeOut(1);
                    if (player.InventoryManager.TryGiveItemstack(stack)) { MarkDirty(true); return true; }
                    Api.World.SpawnItemEntity(stack, Pos.ToVec3d().Add(0.5, 0.5, 0.5));
                    MarkDirty(true);
                    return true;
                }
                if (!NuggetSlot.Empty)
                {
                    ItemStack stack = NuggetSlot.TakeOut(1);
                    if (player.InventoryManager.TryGiveItemstack(stack)) { MarkDirty(true); return true; }
                    Api.World.SpawnItemEntity(stack, Pos.ToVec3d().Add(0.5, 0.5, 0.5));
                    MarkDirty(true);
                    return true;
                }
            }

            return false;
        }

        public bool Repair(IPlayer player)
        {
            if (ToolSlot.Empty || NuggetSlot.Empty) return false;
            if (ToolSlot.Itemstack.Collectible == null) return false;

            int repairAmount = 1;
            ToolSlot.Itemstack.Collectible.DamageItem(Api.World, player.Entity, ToolSlot, -repairAmount);
            NuggetSlot.TakeOut(repairAmount);
            MarkDirty(true);
            return true;
        }
    }
}
