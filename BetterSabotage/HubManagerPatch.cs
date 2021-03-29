using System;
using HarmonyLib;
using System.Linq;
using InnerNet;
using static Glaucus.BetterSabotage;
using Object = UnityEngine.Object;

namespace Glaucus
{
    [HarmonyPatch(typeof(HudManager))]
    public class HubManagerPatch
    {
        [HarmonyPatch(nameof(HudManager.Update))]
        static void Postfix(HudManager __instance)
        {
            if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
            {
                ReactorTask reactorTask = Object.FindObjectOfType<ReactorTask>();
                if (reactorTask && ReactorSabotageShaking.GetValue() != 0)
                {
                    float reactorCountdown = reactorTask.reactor.Countdown;
                    __instance.PlayerCam.shakeAmount = ShakingValues[ReactorSabotageShaking.GetValue()];
                    __instance.PlayerCam.shakePeriod = 400;
                }
                else
                {
                    __instance.PlayerCam.shakeAmount = 0;
                    __instance.PlayerCam.shakePeriod = 0;
                }
            }
        }
    }
}