using Vintagestory.API.Common;

namespace RepairWorkbenchMod
{
    public class RepairWorkbenchMod : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            api.Logger.Notification("Repair Workbench Mod loaded");
        }
    }
}
