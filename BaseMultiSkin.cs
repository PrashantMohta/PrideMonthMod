using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Satchel;
using UnityEngine;

namespace PrideMonthMod
{
    abstract class BaseMultiSkin {

        public abstract string GetResourceFilter();

        public abstract bool Matcher(GameObject go);

        public bool CheckAndApply(GameObject go)
        {
            if (Matcher(go))
            {
            var uniqueTk2d = go.GetAddComponent<UniqueTk2d>();
            if (!uniqueTk2d.IsUnique)
            {
                uniqueTk2d.MakeUnique().SetTexture(NextTexture());
            }
                return true;
            }
            return false;
        }
        public List<String> GetResourceNames()
        {
            return [.. Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(name => name.Contains(GetResourceFilter()))];
        }

        public BaseMultiSkin() {
            LoadTextures();
        }

        private List<Texture2D> textures;

        public Texture2D NextTexture()
        {
           var randomValue =  All4Love.RNG.NextDouble();
           return textures[(int)Math.Floor(randomValue * textures.Count())];
        }
        public void LoadTextures() {
            var resources = GetResourceNames();
            textures = [.. resources.Select(path => AssemblyUtils.GetTextureFromResources(path))];
        }
    }
}
