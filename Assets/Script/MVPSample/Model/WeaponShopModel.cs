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
            model.Init(playerData, "•Ší‰®", next);
            return model;
        }

        protected override void Init(PlayerData playerData, string title, string next)
        {
            base.Init(playerData, title, next);

            AddGood(new Element(0, ItemType.Weapon, "‚Ğ‚Ì‚«‚Ì‚Ú‚¤", "‚½‚¾‚Ì–_", 10));
            AddGood(new Element(1, ItemType.Weapon, "‚Ç‚¤‚Ì‚Â‚é‚¬", "‰SÒŒü‚¯‚ÌŒ•", 350));
            AddGood(new Element(1, ItemType.Weapon, "‚Í‚ª‚Ë‚Ì‚Â‚é‚¬", "’†‹‰ÒŒü‚¯‚ÌŒ•", 1500));
        }
    }
}