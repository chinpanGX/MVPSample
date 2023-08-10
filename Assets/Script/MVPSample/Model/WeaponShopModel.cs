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
            model.Init(playerData, "���퉮", next);
            return model;
        }

        protected override void Init(PlayerData playerData, string title, string next)
        {
            base.Init(playerData, title, next);

            AddGood(new Element(0, ItemType.Weapon, "�Ђ̂��̂ڂ�", "�����̖_", 10));
            AddGood(new Element(1, ItemType.Weapon, "�ǂ��̂邬", "���S�Ҍ����̌�", 350));
            AddGood(new Element(1, ItemType.Weapon, "�͂��˂̂邬", "�����Ҍ����̌�", 1500));
        }
    }
}