using Modding;
using Satchel.BetterPreloads;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BossStatueCompletionStates;
using UObject = UnityEngine.Object;

namespace PrideMonthMod
{
    public class All4Love : BetterPreloadsMod<PreloadsHolder>
    {
        internal static All4Love Instance;
        internal static System.Random RNG = new System.Random();
        internal static List<BaseMultiSkin> items;


        public All4Love() 
        {
            Instance = this;
            
        }

        public override void Initialize()
        {
            Instance = this;
            items = new List<BaseMultiSkin> {
                new NamedEnemy("Fungling").ShouldMatch(Preloads.Fungling),
                new NamedEnemy("Tiktik").ShouldMatch(Preloads.Tiktik),
                new NamedEnemy("ShadowCreepers").ShouldMatch(Preloads.ShadowCreepers), 
                new NamedEnemy("Crawlid").ShouldMatch(Preloads.Crawlid),
                new NamedEnemy("MageBalloon").ShouldMatch(Preloads.Folly),
                new NamedEnemy("MageBlob").ShouldMatch(Preloads.Mistake)
            };
            On.tk2dSprite.Awake += Tk2dSprite_Awake;
        }

        private void Tk2dSprite_Awake(On.tk2dSprite.orig_Awake orig, tk2dSprite self)
        {
            CheckAndApply(self.gameObject);
            orig(self);
        }

        private void CheckAndApply(GameObject gameObject)
        {
            items.Find(item => item.CheckAndApply(gameObject));
        }

    }
}