using HarmonyLib;
using UnhollowerBaseLib;
using UnityEngine;

namespace Glaucus
{
    [HarmonyPatch(typeof(GameSettingMenu), nameof(GameSettingMenu.OnEnable))]
    public static class GameSettingsMenuPatch
    {
        public static void Prefix(ref GameSettingMenu __instance)
        {
            __instance.HideForOnline = new Il2CppReferenceArray<Transform>(0);
        }
    }
}