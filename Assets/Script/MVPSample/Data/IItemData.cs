using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPSample.Data
{
    public enum ItemType
    {
        None,
        Item,
        Weapon
    }

    public interface IItemData
    {
        ItemType Type { get; }
        string Name { get; }
        int Num { get; }
        void SetNum(int num);
    }
}