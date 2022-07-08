using SlimeRanger.Helpers;
using UnityEngine;

namespace SlimeRanger.Hacks
{
    internal class Misc
    {
		public static void Fly(float speed) //normal speed 50f
		{
			TeleportablePlayer tpp = UnityEngine.Object.FindObjectOfType<TeleportablePlayer>();
			Vector3 pos = tpp.transform.position;

			if (Input.GetKey(KeyCode.Z))
			{
				pos += tpp.transform.forward * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.S))
			{
				pos += -tpp.transform.forward * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.D))
			{
				pos += tpp.transform.right * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.Q))
			{
				pos += -tpp.transform.right * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.Space))
			{
				pos += tpp.transform.up * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.LeftShift))
			{
				pos += -tpp.transform.up * speed * Time.deltaTime;
			}

			Misc.SetPlayerPosition(pos);
		}

		public static void AddCurrency(int amount, PlayerState.CoinsType type = PlayerState.CoinsType.NORM)
        {
            StateHelpers.GetPlayerState().AddCurrency(amount, type);
        }

		public static void AddKey()
        {
            StateHelpers.GetPlayerState().AddKey();
        }

        public static void SetEnergy(int amount)
        {
            StateHelpers.GetPlayerState().SetEnergy(amount);
        }

        public static void SetHealth(int amount)
        {
            StateHelpers.GetPlayerState().SetHealth(amount);
        }

        public static void SetPlayerPosition(Vector3 position)
        {
            TeleportablePlayer tpp = UnityEngine.Object.FindObjectOfType<TeleportablePlayer>();
            tpp.playerEventHandler.Position.Set(position);
        }

	}
}
