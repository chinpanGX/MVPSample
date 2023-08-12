using MVPSample.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPSample.Model
{
    public class WeaponShopModel : ShopModel
    {
        public static WeaponShopModel Create(PlayerData playerData, string next = "")
        {
            var model = new WeaponShopModel();
            model.Init(playerData, "武器屋", next);
            return model;
        }

        protected override void Init(PlayerData playerData, string title, string next)
        {
            base.Init(playerData, title, next);

            AddGood(new Element(0, ItemType.Weapon, "ひのきのぼう", "ただのぼう", 10));
            AddGood(new Element(1, ItemType.Weapon, "どうのつるぎ", "初心者向けの剣", 350));
            AddGood(new Element(2, ItemType.Weapon, "はがねのつるぎ", "中級者向けの剣", 1500));
            AddGood(new Element(3, ItemType.Weapon, "はじゃのつるぎ", "世界を制覇したものが使っていた剣", 4500));
        }
    }
}