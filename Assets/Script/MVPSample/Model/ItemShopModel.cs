#nullable enable
using MVPSample.Data;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
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
            AddGood(new Element(0, ItemType.Item, "やくそう", "仲間ひとりのHPを30〜40程回復", 8));
            AddGood(new Element(1, ItemType.Item, "上やくそう", "仲間ひとりのHPを50〜回復", 300));
            AddGood(new Element(2, ItemType.Item, "キメラのつばさ", "一番最後へ行った町へ移動する", 0));
        }
    }
}