using UnityEngine;

namespace PrideMonthMod
{
    internal class NamedEnemy(string resourceName) : BaseMultiSkin
    {
        public override string GetResourceFilter() => resourceName;

        private Material originalMaterial;
        public BaseMultiSkin ShouldMatch(GameObject go)
        {
            originalMaterial = go.GetComponent<tk2dSprite>()?.CurrentSprite?.material;
            return this;
        }

        public override bool Matcher(GameObject go)
        {
            if (originalMaterial == null) return false;
            return go.GetComponent<tk2dSprite>()?.CurrentSprite?.material == originalMaterial;
        }

    }
}