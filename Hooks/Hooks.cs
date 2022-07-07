using UnityEngine;
using HarmonyLib;
using SlimeRanger.Settings;
using SlimeRanger.Helpers;
using System.Runtime;
using System;

namespace SlimeRanger.Hooks
{
    internal class Hooks
    {

        // Used for TPs to home
        [HarmonyPatch(typeof(DisplayOnMap))]
        [HarmonyPatch(nameof(DisplayOnMap.ShowOnMap))] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class DisplayOnMap_ShowOnMap
        {
            static void Postfix(ref bool __result)
            {
                if (Settings.Settings.map_reveal)
                {
                    __result = true;
                }
                
                return;
            }
        }

        // Used to delete the fog
        [HarmonyPatch(typeof(PlayerState))]
        [HarmonyPatch(nameof(PlayerState.HasUnlockedMap))] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class PlayerState_HasUnlockedMap
        {
            static void Postfix(ref bool __result)
            {
                if (Settings.Settings.map_reveal)
                {
                    __result = true;
                }
                
                return;
            }
        }

        // Used for the godmode
        [HarmonyPatch(typeof(PlayerState))]
        [HarmonyPatch(nameof(PlayerState.CanBeDamaged))] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class PlayerState_CanBeDamaged
        {
            static void Postfix(ref bool __result)
            {
                __result = !Settings.Settings.godmode;
                return;
            }
        }

        [HarmonyPatch(typeof(PlayerState))]
        [HarmonyPatch(nameof(PlayerState.AddRads))] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class PlayerState_AddRads
        {
            static void Prefix(ref float rads)
            {
                if (Settings.Settings.no_rad)
                {
                    rads = 0f;
                }
                return;
            }
        }

        [HarmonyPatch(typeof(PlayerState))]
        [HarmonyPatch(nameof(PlayerState.SpendEnergy))] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class PlayerState_SpendEnergy
        {
            static void Prefix(ref float energy)
            {
                if (Settings.Settings.infinite_energy)
                {
                    energy = 0f;
                }

                return;
            }
        }

        [HarmonyPatch(typeof(EnergyJetpack))]
        [HarmonyPatch("CanStart_Jetpack")] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class PlayerState_CanStart_Jetpack
        {
            static void Postfix(ref bool __result)
            {
                if (Settings.Settings.fly)
                {
                    __result = false;
                }
                return;
            }
        }
    }
}
