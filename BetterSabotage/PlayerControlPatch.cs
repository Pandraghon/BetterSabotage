using HarmonyLib;

namespace Glaucus
{
    [HarmonyPatch(typeof(PlayerControl))]
    class PlayerControlPatch
    {
        [HarmonyPatch(nameof(PlayerControl.AddSystemTask))]
        static void Postfix(SystemTypes IBKONFPFHAB)
        {
            System.Console.WriteLine("AddSystemTask");
            SystemTypes system = IBKONFPFHAB;
            switch (system)
            {
                case SystemTypes.Comms:
                    if (BetterSabotage.CommsSabotageAnonymous.GetValue() == 1 && !PlayerControl.LocalPlayer.Data.IsImpostor
                        || BetterSabotage.CommsSabotageAnonymous.GetValue() == 2)
                        foreach (PlayerControl playerControl in PlayerControl.AllPlayerControls)
                            playerControl.getModded().SetAnonymous();
                    break;
            }
        }
        
        [HarmonyPatch(nameof(PlayerControl.RemoveTask))]
        static void Postfix(PlayerTask HHCGLKKJDLA)
        {
            System.Console.WriteLine("RemoveTask");
            PlayerTask task = HHCGLKKJDLA;
            switch (task.TaskType)
            {
                case TaskTypes.FixComms:
                    if (BetterSabotage.CommsSabotageAnonymous.GetValue() == 1 && !PlayerControl.LocalPlayer.Data.IsImpostor
                        || BetterSabotage.CommsSabotageAnonymous.GetValue() == 2)
                        foreach (PlayerControl playerControl in PlayerControl.AllPlayerControls)
                            playerControl.getModded().RemoveAnonymous();
                    break;
            }
        }
    }
}