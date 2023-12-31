# nullable enable
using System.Collections;
using System.Collections.Generic;
using Core;
using Scriptable;
using MVPSample.View;
using UnityEngine;

namespace Common.Factory
{
    public static class PrefabsFactory
    {
        static ViewPrefabsSetting viewPrefabsSetting = null!;

        public static void Init()
        {
            viewPrefabsSetting = Resources.Load<ViewPrefabsSetting>("ViewPrefabsSetting");
        }

        public static TopView CreateTopView()
        {
            return GameObject.Instantiate<TopView>(viewPrefabsSetting.TopViewPrefabs);
        }

        public static ShopView CreateShopView()
        {
            return GameObject.Instantiate<ShopView>(viewPrefabsSetting.ShopViewPrefabs);
        }
    }
}