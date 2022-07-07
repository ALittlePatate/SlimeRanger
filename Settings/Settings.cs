using UnityEngine;

namespace SlimeRanger.Settings
{
    public class Settings
    {
        public static bool menu_enable = false;
        public static float width = Screen.width / 2f;
        public static float height = Screen.height / 2f;
        public static float x = 0;
        public static float y = 0;

        public static Vector3 savedposition;

        public static bool map_reveal = false;
        public static bool godmode = false;
        public static bool no_rad = false;
        public static bool infinite_energy = false;
        public static bool fly = false;
        public static float fly_speed = 50f;
        public static float energy_to_set = 0f;
        public static float health_to_set = 0f;
        public static float money_to_add = 0f;
    }
}
