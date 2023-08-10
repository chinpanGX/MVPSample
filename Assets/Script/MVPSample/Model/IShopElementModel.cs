using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVPSample.Data;

namespace MVPSample.Model
{
    public interface IShopElementModel
    {
        int UniqueId { get; }
        ItemType Type { get; }
        string Name { get; }
        string Description { get; }
        int Price { get; }
    }
}