using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BossStatueCompletionStates;
using UObject = UnityEngine.Object;

namespace PrideMonthMod
{
    public class PrideMonthMod : Mod
    {
        internal static PrideMonthMod Instance;
        internal static System.Random RNG = new System.Random();
        internal static List<BaseMultiSkin> items = new List<BaseMultiSkin> { 
            new FsmNamedEnemy("Fungling","Fungoon Baby"), //fungling
            new ObjectNamedEnemy("Tiktik","Climber"), //tiktik
            new ObjectNamedEnemy("ShadowCreepers","Abyss Crawler"), //shadow creepers
            new FsmNamedEnemy("Crawlid","Crawler"), //Crawlid
            new FsmNamedEnemy("MageBalloon","Mage Balloon"), //MageBlob
            new FsmNamedEnemy("MageBlob","Mage Blob"), //MageBlob
        };
        public PrideMonthMod() : base("PrideMonthMod")
        {
            Instance = this;
        }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Instance = this;
            On.HealthManager.Start += HealthManager_Start;
            On.PlayMakerFSM.Awake += PlayMakerFSM_Awake;
        }

        private void PlayMakerFSM_Awake(On.PlayMakerFSM.orig_Awake orig, PlayMakerFSM self)
        {
            items.Find(item => item.CheckAndApply(self.FsmName,self.gameObject));
            orig(self);
        }

        private void HealthManager_Start(On.HealthManager.orig_Start orig, HealthManager self)
        {
            items.Find(item => item.CheckAndApply("HealthManager", self.gameObject));
            orig(self);
        }
    }
}