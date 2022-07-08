using UnityEngine;
using HarmonyLib;
using SlimeRanger.Settings;
using SlimeRanger.Helpers;
using System.Runtime;
using System.Linq;
using System.Reflection;
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

        [HarmonyPatch(typeof(GordoDisplayOnMap))]
        [HarmonyPatch(nameof(GordoDisplayOnMap.ShowOnMap))] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class GordoDisplayOnMap_ShowOnMap
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
        static class EnergyJetpack_CanStart_Jetpack
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

        [HarmonyPatch(typeof(EnergyJetpack))]
        [HarmonyPatch("DownwardExtraGravity")] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class EnergyJetpack_DownwardExtraGravity
        {
            static void Prefix(ref float y, ref float yVel)
            {
                if (Settings.Settings.infinite_jetpack)
                {
                    yVel = 0f;
                    y = 0f;
                }
                
                return;
            }
        }

        [HarmonyPatch(typeof(LandPlotUI))]
        [HarmonyPatch("BuyPlot")] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class LandPlotUI_BuyPlot
        {
            static void Prefix(ref LandPlotUI.PlotPurchaseItem plot)
            {
                if (Settings.Settings.max_plot)
                {
                    Settings.Settings.plot = plot;
                }
                return;
            }
        }

        [HarmonyPatch(typeof(LandPlotUI))]
        [HarmonyPatch("BuyPlot")] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class LandPlotUI_BuyPlot_post
        {
            static void Postfix(ref bool __result)
            {
                if (__result == true && Settings.Settings.plot != null && Settings.Settings.max_plot)
                {
                    Settings.Settings.plot.plotPrefab.gameObject.SetActive(true);

                    LandPlot landPlot = UnityEngine.Object.FindObjectOfType<LandPlot>();

                    foreach (LandPlot.Upgrade upgrade in Enum.GetValues(typeof(LandPlot.Upgrade)))
                    {
                        if (upgrade == LandPlot.Upgrade.SOLAR_SHIELD) //yeah nah we don't want solar shield, most of the slimes don't need that
                        {
                            continue;
                        }
                        landPlot.AddUpgrade(upgrade);
                    }
                }
                return;
            }
        }

        [HarmonyPatch(typeof(AmmoModel))]
        [HarmonyPatch(nameof(AmmoModel.GetSlotMaxCount))] //annotation boiler plate to tell Harmony what to patch. Refer to docs.
        static class AmmoModel_GetSlotMaxCount
        {
            static void Postfix(ref int __result)
            {
                if (Settings.Settings.max_slot_override)
                {
                    __result = (int)Settings.Settings.max_slot;
                }
                
                return;
            }
        }
    }
}
