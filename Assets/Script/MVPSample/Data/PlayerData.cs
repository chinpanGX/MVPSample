#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace MVPSample.Data
{
    public class PlayerData
    {
        public readonly static PlayerData Instance = new PlayerData();

        List<IItemData> items = new ();
        int gold = 0;

        public int Gord => gold;
        public List<IItemData>　Items => items;

        /// <summary>
        /// 所持金の設定
        /// </summary>
        /// <param name="gold"></param>
        public void SetGold(int gold)
        {
            this.gold = gold;
        }
        
        /// <summary>
        /// アイテムの追加
        /// </summary>
        /// <param name="name"></param>
        public void AddItem(string name)
        {
            var item = GetItem(name);
            if(item != null)
            {
                item.SetNum(item.Num + 1);
            }
            else
            {
                items.Add(new ItemData(ItemType.Item, name, 1));
            }
        }

        /// <summary>
        /// 武器の追加
        /// </summary>
        /// <param name="name"></param>
        public void AddWeapon(string name)
        {
            var item = GetItem(name);
            if (item != null)
            {
                item.SetNum(item.Num + 1);
            }
            else
            {
                items.Add(new WeaponData(ItemType.Weapon, name, 1));
            }
        }

        /// <summary>
        /// アイテムの取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ItemData? GetItem(string name) 
        {
            foreach (ItemData item in items) 
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 武器の取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public WeaponData? GetWeapon(string name)
        {
            foreach (WeaponData item in items)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}