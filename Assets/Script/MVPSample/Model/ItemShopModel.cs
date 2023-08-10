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
            model.Init(playerData, "���", next);
            return model;            
        }

        protected override void Init(PlayerData playerData, string title, string next)
        {
            base.Init(playerData, title, next);
            AddGood(new Element(0, ItemType.Item, "�₭����", "���ԂЂƂ��HP��30�`40����", 8));
            AddGood(new Element(1, ItemType.Item, "��₭����", "���ԂЂƂ��HP��50�`��", 300));
            AddGood(new Element(2, ItemType.Item, "�L�����̂΂�", "��ԍŌ�֍s�������ֈړ�����", 0));
        }
    }
}