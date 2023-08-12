using System;
using System.Collections;
using System.Collections.Generic;
using MVPSample.Data;
using MVPSample.Model;
using UnityEngine;

namespace Scriptable
{
    [Serializable]
    public class Element : IShopElementModel
    {
        [SerializeField] int uniqueId = -1;
        [SerializeField] ItemType itemType = ItemType.None;
        [SerializeField] string name = string.Empty;
        [SerializeField] string desc = string.Empty;
        [SerializeField] int price = 0;

        public int UniqueId => uniqueId;
        public ItemType Type => itemType;
        public string Name => name;
        public string Description => desc;
        public int Price => price;
    }

    [CreateAssetMenu()]
    public class GoodsDataBase : ScriptableObject
    {
        [SerializeField] Element[] element;

        public Element[] Elements => element;
    }
}