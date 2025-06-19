using Vintagestory.API.Common;

namespace RepairWorkbenchMod
{
    public class RepairWorkbenchMod : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterBlockClass("BlockRepairBench", typeof(RepairWorkbench.BlockRepairBench));
            api.RegisterBlockEntityClass("BlockEntityRepairBench", typeof(RepairWorkbench.BlockEntityRepairBench));
            api.RegisterItemClass("ItemRepairHammer", typeof(RepairWorkbench.ItemRepairHammer));

            api.Logger.Notification("Repair Workbench Mod loaded");
        }
    }
}
