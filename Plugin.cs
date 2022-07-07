using BepInEx;
using UnityEngine;
using HarmonyLib;
using UnityEngine.UI;
using System.Collections.Generic;
using SlimeRanger.Helpers;
using System.Collections;
using SlimeRanger.Hooks;

namespace SlimeRanger
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("SlimeRancher.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo("SlimeRanger loaded !");

            var harmony = new Harmony("com.example.patch");
            harmony.PatchAll();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                Settings.Settings.menu_enable = !Settings.Settings.menu_enable;
            }

            if (Settings.Settings.fly)
            {
                Hacks.Misc.Fly(Settings.Settings.fly_speed);
            }
        }

        private void OnGUI()
        {
            if (Settings.Settings.menu_enable) //Si on appuie sur INSERT
            {
                GUIStyle StatesLabel;
                StatesLabel = new GUIStyle(GUI.skin.label)
                {
                    alignment = TextAnchor.MiddleLeft,
                    margin = new RectOffset(),
                    padding = new RectOffset(),
                    fontSize = 25,
                    fontStyle = FontStyle.Bold
                };

                GUIStyle Statestoggle;
                Statestoggle = new GUIStyle(GUI.skin.toggle)
                {
                    fontSize = 20,
                    fontStyle = FontStyle.Bold
                };

                GUI.contentColor = Color.cyan;

                GUI.Label(new Rect(200, Settings.Settings.y, 200, 50), "SlimeRanger", StatesLabel); //Titre du menu

                Settings.Settings.map_reveal = GUI.Toggle(new Rect(200, Settings.Settings.y + 50, 130, 25), Settings.Settings.map_reveal, "Reveal map", Statestoggle);
                Settings.Settings.godmode = GUI.Toggle(new Rect(200, Settings.Settings.y + 80, 130, 25), Settings.Settings.godmode, "Godmode", Statestoggle);

                if (GUI.Button(new Rect(200, Settings.Settings.y + 110, 110, 20), "Add key"))
                {
                    Hacks.Misc.AddKey();
                    Logger.LogInfo("Key added");
                }

                if (GUI.Button(new Rect(200, Settings.Settings.y + 140, 110, 20), "Upgrade All"))
                {
                    Hacks.Unlocks.UnlockAllUpgrades();
                    Logger.LogInfo("All upgrades unlocked !");
                }

                if (GUI.Button(new Rect(200, Settings.Settings.y + 170, 110, 20), "Set energy"))
                {
                    Hacks.Misc.SetEnergy((int)Settings.Settings.energy_to_set);
                    Logger.LogInfo("Energy added !");
                }
                GUI.Label(new Rect(200, Settings.Settings.y + 190, 200, 30), "Energy Amount : ");
                Settings.Settings.energy_to_set = GUI.HorizontalSlider(new Rect(200, Settings.Settings.y + 210, 100, 10), Settings.Settings.energy_to_set, 0f, 1000f);
                GUI.Label(new Rect(305, Settings.Settings.y + 205, 100, 30), ((int)Settings.Settings.energy_to_set).ToString());

                if (GUI.Button(new Rect(200, Settings.Settings.y + 230, 110, 20), "Set Health"))
                {
                    Hacks.Misc.SetHealth((int)Settings.Settings.health_to_set);
                    Logger.LogInfo("Health added !");
                }
                GUI.Label(new Rect(200, Settings.Settings.y + 250, 200, 30), "Health Amount : ");
                Settings.Settings.health_to_set = GUI.HorizontalSlider(new Rect(200, Settings.Settings.y + 270, 100, 10), Settings.Settings.health_to_set, 0f, 1000f);
                GUI.Label(new Rect(305, Settings.Settings.y + 265, 100, 30), ((int)Settings.Settings.health_to_set).ToString());

                if (GUI.Button(new Rect(200, Settings.Settings.y + 290, 110, 20), "Add money"))
                {
                    Hacks.Misc.AddCurrency((int)Settings.Settings.money_to_add);
                    Logger.LogInfo("Money added !");
                }
                GUI.Label(new Rect(200, Settings.Settings.y + 310, 200, 30), "Amount : ");
                Settings.Settings.money_to_add = GUI.HorizontalSlider(new Rect(200, Settings.Settings.y + 330, 100, 10), Settings.Settings.money_to_add, 0f, 1000f);
                GUI.Label(new Rect(305, Settings.Settings.y + 325, 100, 30), ((int)Settings.Settings.money_to_add).ToString());

                Settings.Settings.no_rad = GUI.Toggle(new Rect(350, Settings.Settings.y + 50, 130, 25), Settings.Settings.no_rad, "No rad", Statestoggle);
                Settings.Settings.infinite_energy = GUI.Toggle(new Rect(350, Settings.Settings.y + 80, 130, 25), Settings.Settings.infinite_energy, "∞ energy", Statestoggle);
                
                Settings.Settings.fly = GUI.Toggle(new Rect(350, Settings.Settings.y + 110, 130, 25), Settings.Settings.fly, "Fly", Statestoggle);
                GUI.Label(new Rect(350, Settings.Settings.y + 130, 200, 30), "Speed : ");
                Settings.Settings.fly_speed = GUI.HorizontalSlider(new Rect(350, Settings.Settings.y + 150, 100, 10), Settings.Settings.fly_speed, 0f, 100f);
                GUI.Label(new Rect(455, Settings.Settings.y + 145, 100, 30), ((int)Settings.Settings.fly_speed).ToString());

                if (GUI.Button(new Rect(350, Settings.Settings.y + 175, 110, 20), "Save position"))
                {
                    Settings.Settings.savedposition = StateHelpers.GetPlayerPosition();
                    Logger.LogInfo("Saved position : " + Settings.Settings.savedposition.ToString());
                }

                if (GUI.Button(new Rect(350, Settings.Settings.y + 205, 110, 20), "Goto position"))
                {
                    if (Settings.Settings.savedposition != null)
                    {
                        Hacks.Misc.SetPlayerPosition(Settings.Settings.savedposition);
                        Logger.LogInfo("Teleported to position : " + Settings.Settings.savedposition.ToString());
                    }
                }
            }
        }
    }
}