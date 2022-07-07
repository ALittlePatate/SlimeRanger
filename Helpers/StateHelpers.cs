using UnityEngine;

namespace SlimeRanger.Helpers
{
    internal class StateHelpers
    {
        public static PlayerState GetPlayerState()
        {
            return UnityEngine.Object.FindObjectOfType<PlayerState>();
        }
        public static Vector3 GetPlayerPosition()
        {
            TeleportablePlayer tpp = UnityEngine.Object.FindObjectOfType<TeleportablePlayer>();
            return tpp.playerEventHandler.Position.Get();
        }
    }
}
