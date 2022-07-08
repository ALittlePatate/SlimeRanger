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

            ProgressDirector progressDirector = UnityEngine.Object.FindObjectOfType<ProgressDirector>();
            foreach (ProgressDirector.ProgressType pt in Enum.GetValues(typeof(ProgressDirector.ProgressType)))
            {
                progressDirector.AddProgress(pt);
            }

            foreach (Gadget.Id id in Enum.GetValues(typeof(Gadget.Id)))
            {
                SRSingleton<SceneContext>.Instance.GadgetDirector.AddBlueprint(id);
            }

            progressDirector.AddProgress(ProgressDirector.ProgressType.CORPORATE_PARTNER);
            CorporatePartnerUI corporatePartnerUI = UnityEngine.Object.FindObjectOfType<CorporatePartnerUI>();
            corporatePartnerUI.RebuildUI();
            corporatePartnerUI.PlayPurchaseFX();
            SRSingleton<SceneContext>.Instance.PediaDirector.UnlockWithoutPopup(PediaDirector.Id.CHROMA);
            SRSingleton<SceneContext>.Instance.PediaDirector.UnlockWithoutPopup(PediaDirector.Id.SLIME_TOYS);

            PediaDirector pediaDirector = UnityEngine.Object.FindObjectOfType<PediaDirector>();
            foreach (PediaDirector.Id id in Enum.GetValues(typeof(PediaDirector.Id)))
            {
                pediaDirector.Unlock(id);
            }
        }
    }
}
