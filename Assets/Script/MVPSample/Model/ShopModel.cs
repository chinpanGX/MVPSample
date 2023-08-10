#nullable enable
using MVPSample.Data;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;

namespace MVPSample.Model
{
    public class ShopModel : IShopModel
    {
        protected class Element : IShopElementModel
        {
            public int UniqueId { get; private set; } = -1;

            public ItemType Type { get; private set; } = ItemType.None;

            public string Name { get; private set; } = string.Empty;

            public string Description { get; private set; } = string.Empty;

            public int Price { get; private set; } = 0;
            
            public Element(int uniqueId, ItemType type, string name, string desc, int price)    
            {
                UniqueId = uniqueId;
                Type = type;
                Name = name;
                Description = desc;
                Price = price;
            }
        }

        PlayerData playerData = null!;
        string title = string.Empty;
        int gold = 0;
        string next = string.Empty;
        List<IShopElementModel> goods = new();
        List<IShopElementModel> items = new();

        public string Title => title;

        public int Gold => gold;

        public string Next => next;

        public List<IShopElementModel> Goods => goods;

        public List<IShopElementModel> Items => items;


        protected virtual void Init(PlayerData playerData, string title, string next)
        {
            this.playerData = playerData;
            this.title = title;
            this.gold = playerData.Gord;
            this.next = next;
            goods.Clear();
            items.Clear();                
        }

        /// <summary>
        /// 所持金の設定
        /// </summary>
        /// <param name="gold"></param>
        public virtual void SetGold(int gold)
        {
            this.gold = gold;
            playerData.SetGold(gold);
        }

        /// <summary>
        /// 所持アイテムの追加
        /// </summary>
        /// <param name="element"></param>
        public virtual void AddItem(IShopElementModel element)
        {
            Items.Add(element);
        }

        /// <summary>
        /// 所持アイテムの取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual ItemData? GetItem(string name)
        {
            return playerData.GetItem(name);
        }

        /// <summary>
        /// 商品の追加
        /// </summary>
        /// <param name="element"></param>
        public virtual void AddGood(IShopElementModel element)
        {
            Goods.Add(element);
        }

        /// <summary>
        /// 商品の取得
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public virtual IShopElementModel? GetGoods(int uniqueId)
        {
            if(uniqueId != -1)
            {
                foreach(IShopElementModel element in Goods)
                {
                    if(element?.UniqueId == uniqueId)
                    {
                        return element;
                    }
                }
            }
            return null;
        }       

        public virtual void SetNext(string next)
        {
            this.next = next;
        }
    }
}