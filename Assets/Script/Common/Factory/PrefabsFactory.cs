# nullable enable
using System.Collections;
using System.Collections.Generic;
using Scriptable;
using UnityEngine;

namespace Common.Factory
{
    public static class PrefabsFactory
    {
        [SerializeField] static ViewPrefabsSetting viewPrefabsSetting = null!;

        public static TopView CreateTopView()
        {
            return Object.Instantiate(viewPrefabsSetting.TopViewPrefabs);
        }
    }
}