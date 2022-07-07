using UnityEngine;
using SlimeRanger.Helpers;
using System;

namespace SlimeRanger.Hacks
{
    internal class Unlocks
    {
        public static void UnlockAllUpgrades()
        {
            foreach (PlayerState.Upgrade up in Enum.GetValues(typeof(PlayerState.Upgrade)))
            {
                StateHelpers.GetPlayerState().AddUpgrade(up);
            }
        }
    }
}
