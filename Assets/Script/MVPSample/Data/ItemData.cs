using MVPSample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPSample.Data
{
    public class ItemData : IItemData
    {
        ItemType type = ItemType.None;
        string name = string.Empty;
        int num = 0;

        public ItemType Type => type;

        public string Name => name;

        public int Num => num;

        public ItemData(ItemType type, string name, int num)
        {
            this.type = type;
            this.name = name;
            this.num = num;
        }

        public void SetNum(int num)
        {
            this.num = num;
        }
    }
}