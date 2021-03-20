using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.IL2CPP;
using Essentials.Options;
using HarmonyLib;
using Reactor;
using Reactor.Patches;
using UnityEngine;

namespace Glaucus
{
    public class Main
    {
        public static ModdedPalette Palette = new ModdedPalette();
        public static ModdedLogic Logic = new ModdedLogic();
    }

    public class ModdedLogic
    {
        public List<ModdedPlayer> AllModdedPlayer = new List<ModdedPlayer>();
    }
    
    public class ModdedPalette
    {
        public Color UnknownBackColor = new Color(0.3f, 0.3f, 0.3f, 1f);
        public Color UnknownBodyColor = new Color(0.4f, 0.4f, 0.4f, 1f);
    }

    public class ModdedPlayer
    {
        public PlayerControl PlayerControl { get; set; }
        public uint SavedSkin { get; set; }
        public uint SavedHat { get; set; }

        public void SetAnonymous()
        {
            PlayerControl.myRend.material.SetColor("_BackColor", Main.Palette.UnknownBackColor);
            PlayerControl.myRend.material.SetColor("_BodyColor", Main.Palette.UnknownBodyColor);
            PlayerControl.Visible = false; // hide skin, hat, name, pet
            PlayerControl.myRend.enabled = true;
        }

        public void RemoveAnonymous()
        {
            PlayerControl.Visible = true;
            PlayerControl.SetColor(PlayerControl.Data.ColorId);
        }
    }

    public static class Extensions
    {
        public static ModdedPlayer getModded(this PlayerControl player)
        {
            return Main.Logic.AllModdedPlayer.Find(x => x.PlayerControl == player);
        }
    }

    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class BetterSabotage : BasePlugin
    {
        public const string Id = "glaucus.pocus.BetterSabotage";

        //Credit to https://github.com/DorCoMaNdO/Reactor-Essentials
        public static CustomStringOption CommsSabotageAnonymous = CustomOption.AddString("Comms Sabotage Anonymous", new string[] { "Nobody", "Crewmates", "Everyone" });
        public Harmony Harmony { get; } = new Harmony(Id);

        public override void Load()
        {
            CustomOption.ShamelessPlug = false;

            ReactorVersionShower.TextUpdated += (text) =>
            {
                int index = text.Text.LastIndexOf('\n');
                text.Text = text.Text.Insert(index == -1 ? text.Text.Length - 1 : index, 
                    "\n[FFBB66FF]" + typeof(BetterSabotage).Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description + " " + typeof(BetterSabotage).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion + "[] by Pandraghon");
            };
            
            Harmony.PatchAll();
        }
    }
}