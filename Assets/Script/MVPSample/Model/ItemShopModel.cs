#nullable enable
using MVPSample.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPSample.Model
{
    public class ItemShopModel : ShopModel
    {
        public static ItemShopModel Create(PlayerData playerData, string next = "")
        {
            var model = new ItemShopModel();
            model.Init(playerData, "道具屋", next);
            return model;
        }

        protected override void Init(PlayerData playerData, string title, string next)
        {
            base.Init(playerData, title, next);
            AddGood(new Element(0, ItemType.Item, "やくそう", "仲間のHPを30~回復する", 8));
            AddGood(new Element(1, ItemType.Item, "特やくそう", "仲間のHPを50~回復する", 300));
            AddGood(new Element(2, ItemType.Item, "キメラのつばさ", "１番最後に行った町に移動する", 100));
        }
    }
}