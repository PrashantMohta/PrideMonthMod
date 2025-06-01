using UnityEngine;

namespace PrideMonthMod
{
    internal class FsmNamedEnemy(string resourceName, string objectName) : BaseMultiSkin
    {
        public override string GetResourceFilter() => resourceName;

        public override bool Matcher(string fsmName, GameObject go)
        {
            return fsmName == objectName;
        }
    }
    internal class ObjectNamedEnemy(string resourceName, string objectName) : BaseMultiSkin
    {
        public override string GetResourceFilter() => resourceName;

        public override bool Matcher(string fsmName, GameObject go)
        {
            return go.name.StartsWith(objectName);
        }
    }
}