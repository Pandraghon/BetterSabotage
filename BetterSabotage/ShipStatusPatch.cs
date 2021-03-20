using HarmonyLib;

namespace Glaucus
{
    [HarmonyPatch(typeof(ShipStatus))]
    class ShipStatusPatch
    {
        [HarmonyPatch(nameof(ShipStatus.Start))]
        static void Postfix()
        {
            Main.Logic.AllModdedPlayer.Clear();
            
            foreach (PlayerControl player in PlayerControl.AllPlayerControls.ToArray())
            { 
                Main.Logic.AllModdedPlayer.Add(new ModdedPlayer { PlayerControl = player });
            }
        }
    }
}