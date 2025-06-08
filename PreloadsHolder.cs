using Satchel.BetterPreloads;
using UnityEngine;

namespace PrideMonthMod
{
#pragma warning disable CS0649 //because we'll set the values later using reflection
    public class PreloadsHolder {

        [Preload("Ruins1_30", "Mage Balloon")]
        public GameObject Folly;

        [Preload("Ruins1_30", "Mage Blob 1")]
        public GameObject Mistake;

        [Preload("Fungus2_03", "Fungoon Baby")]
        public GameObject Fungling;

        [Preload("Abyss_04", "Abyss Crawler")]
        public GameObject ShadowCreepers;

        [Preload("Cliffs_01", "Crawler")]
        public GameObject Crawlid;

        [Preload("Cliffs_01", "Climber")]
        public GameObject Tiktik;
    }
}