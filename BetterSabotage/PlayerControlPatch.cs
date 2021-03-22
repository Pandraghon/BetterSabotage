using System;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace Glaucus
{
    [HarmonyPatch(typeof(PlayerControl))]
    class PlayerControlPatch
    {
        [HarmonyPatch("CAMJPMDIIMN" /* PlayerControl.Visible */, MethodType.Setter)]
        static void Postfix(PlayerControl __instance, ref bool NJFHEFBMBOD)
        {
            if (!PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.myTasks == null) return;
            if (PlayerControl.LocalPlayer.myTasks.ToArray().Any(task => task.TaskType == TaskTypes.FixComms)
                && (BetterSabotage.CommsSabotageAnonymous.GetValue() == 1 && !PlayerControl.LocalPlayer.Data.IsImpostor
                || BetterSabotage.CommsSabotageAnonymous.GetValue() == 2))
            {
                __instance.MyPhysics.Skin.Visible = false;
                __instance.HatRenderer.gameObject.SetActive(false);
                if (__instance.CurrentPet)
                {
                    __instance.CurrentPet.Visible = false;
                }

                __instance.nameText.gameObject.SetActive(false);
            }
        }
        
        [HarmonyPatch(nameof(PlayerControl.SetPlayerMaterialColors), new Type[] {typeof(int), typeof(Renderer)})]
        static void Postfix(int FGAOHLPPBDL /* colorId */, Renderer FNEEAAEEGLD)
        {
            Renderer rend = FNEEAAEEGLD;
            if (!rend || !PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.myTasks == null) return;
            if (PlayerControl.LocalPlayer.myTasks.ToArray().Any(task => task.TaskType == TaskTypes.FixComms)
                && (BetterSabotage.CommsSabotageAnonymous.GetValue() == 1 && !PlayerControl.LocalPlayer.Data.IsImpostor
                    || BetterSabotage.CommsSabotageAnonymous.GetValue() == 2))
            {
                rend.material.SetColor("_BackColor", Main.Palette.UnknownBackColor);
                rend.material.SetColor("_BodyColor", Main.Palette.UnknownBodyColor);
            }
        }
        
        [HarmonyPatch(nameof(PlayerControl.SetPlayerMaterialColors), new Type[] {typeof(Color), typeof(Renderer)})]
        static void Postfix(Color JMDILEGDONK, Renderer FNEEAAEEGLD)
        {
            Renderer rend = FNEEAAEEGLD;
            if (!rend || !PlayerControl.LocalPlayer) return;
            if (BetterSabotage.CommsSabotageAnonymous.GetValue() == 1 && !PlayerControl.LocalPlayer.Data.IsImpostor
                || BetterSabotage.CommsSabotageAnonymous.GetValue() == 2)
            {
                rend.material.SetColor("_BackColor", Main.Palette.UnknownBackColor);
                rend.material.SetColor("_BodyColor", Main.Palette.UnknownBodyColor);
            }
        }
        
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