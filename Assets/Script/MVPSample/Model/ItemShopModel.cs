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
            model.Init(playerData, "“¹‹ï‰®", next);
            return model;            
        }

        protected override void Init(PlayerData playerData, string title, string next)
        {
            base.Init(playerData, title, next);
            AddGood(new Element(0, ItemType.Item, "‚â‚­‚»‚¤", "’‡ŠÔ‚Ğ‚Æ‚è‚ÌHP‚ğ30`40’ö‰ñ•œ", 8));
            AddGood(new Element(1, ItemType.Item, "ã‚â‚­‚»‚¤", "’‡ŠÔ‚Ğ‚Æ‚è‚ÌHP‚ğ50`‰ñ•œ", 300));
            AddGood(new Element(2, ItemType.Item, "ƒLƒƒ‰‚Ì‚Â‚Î‚³", "ˆê”ÔÅŒã‚Ös‚Á‚½’¬‚ÖˆÚ“®‚·‚é", 0));
        }
    }
}