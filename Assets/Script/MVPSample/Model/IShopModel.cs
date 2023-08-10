#nullable enable
using MVPSample.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPSample.Model
{
    public interface IShopModel
    {
        string Title { get; }
        int Gold { get; }
        string Next { get; }
        List<IShopElementModel> Goods { get; }
        List<IShopElementModel> Items { get; }
        void SetGold(int gold);
        IShopElementModel? GetGoods(int uniqueId);
        void AddItem(IShopElementModel element);
        ItemData? GetItem(string name);
        void AddGood(IShopElementModel element);
    }
}