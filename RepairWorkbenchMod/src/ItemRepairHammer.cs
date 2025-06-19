
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;

namespace RepairWorkbench
{
    public class ItemRepairHammer : Item
    {
        public override bool OnHeldInteractStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            if (blockSel != null)
            {
                var be = byEntity.World.BlockAccessor.GetBlockEntity(blockSel.Position) as BlockEntityRepairBench;
                if (be != null)
                {
                    var player = (byEntity as EntityPlayer)?.Player;
                    if (player != null)
                    {
                        if (be.Repair(player))
                        {
                            handling = EnumHandHandling.PreventDefault;
                            return true;
                        }
                    }
                }
            }

            return base.OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }
    }
}
