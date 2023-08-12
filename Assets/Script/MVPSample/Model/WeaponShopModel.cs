using MVPSample.Data;
using Scriptable;
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
            var db = Resources.Load<GoodsDataBase>("WeaponDatabase");
            base.Init(playerData, title, next);
            foreach (var item in db.Elements)
            {
                AddGood(item);
            }
        }
    }
}