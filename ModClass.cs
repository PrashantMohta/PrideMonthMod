using All4Love.Resources;
using HKMirror.Reflection.InstanceClasses;
using Modding;
using Satchel;
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
            On.KnightHatchling.FixedUpdate += KnightHatchling_FixedUpdate;
            On.WeaverlingEnemyList.OnTriggerEnter2D += WeaverlingEnemyList_OnTriggerEnter2D;
            On.GrimmEnemyRange.OnTriggerEnter2D += GrimmEnemyRange_OnTriggerEnter2D;
        }

        private void GrimmEnemyRange_OnTriggerEnter2D(On.GrimmEnemyRange.orig_OnTriggerEnter2D orig, GrimmEnemyRange self, Collider2D otherCollider)
        {
            if (otherCollider.GetComponent<Friend>() == null)
            {
                orig(self, otherCollider);
            }
        }

        private void WeaverlingEnemyList_OnTriggerEnter2D(On.WeaverlingEnemyList.orig_OnTriggerEnter2D orig, WeaverlingEnemyList self, Collider2D otherCollider)
        {
            if(otherCollider.GetComponent<Friend>() == null) { 
                orig(self, otherCollider);
            }
        }

        private void KnightHatchling_FixedUpdate(On.KnightHatchling.orig_FixedUpdate orig, KnightHatchling self)
        {
            try
            {
                var selfR = new KnightHatchlingR(self);
                if (selfR.target != null && selfR.target.GetComponent<Friend>() != null)
                {
                    selfR.target = null;
                    ReflectionHelper.SetField(self, "currentState", self.LastFrameState);
                }
            }
            catch (Exception e) { }
            orig(self);
        }

        private void Tk2dSprite_Awake(On.tk2dSprite.orig_Awake orig, tk2dSprite self)
        {
            CheckAndApply(self.gameObject);
            orig(self);
        }

        private void CheckAndApply(GameObject gameObject)
        {
           var item = items.Find(item => item.CheckAndApply(gameObject));
            if (item != null) {
                gameObject.GetAddComponent<Friend>();
            }
        }

    }
}