#nullable enable
using MVPSample.Data;
using Scriptable;
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
            var db = Resources.Load<GoodsDataBase>("ItemDatabase");

            base.Init(playerData, title, next);
            foreach (var item in db.Elements)
            {
                AddGood(item);
            }
        }
    }
}