#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using Common.UI;
using UnityEngine;

namespace MVPSample.View
{
    public interface IShopNode
    {
        int UniqueId { get; }
        void SetUniqueId(int uniqueId);
        void SetName(string name);
        void SetPrice(int price);
        void SetButtonAction(System.Action<IShopNode?> action);
        void SetTextColor(Color color);
        void Sort();
    }

    public class ShopNode : MonoBehaviour, IShopNode
    {
        [SerializeField] UIButton? button;
        [SerializeField] UIText? label;
        [SerializeField] UIText? price;

        int uniqueId = -1;

        public int UniqueId => uniqueId;

        public void SetUniqueId(int uniqueId)
        {
            this.uniqueId = uniqueId;
        }

        public void SetName(string name)
        {
            this.label.SetTextSafe(name);
        }

        public void SetPrice(int price)
        {
            this.price.SetTextSafe($"{price}G");
        }
        public void SetButtonAction(Action<IShopNode?> action)
        {
            button.AddClickListenerSafe(() => action(this));
        }

        public void SetTextColor(Color color)
        {
            label.SetColorSafe(color);
            price.SetColorSafe(color);
        }

        public void Sort()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if (child.name == "cursor")
                    child.SetSiblingIndex(0);
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if (child.name != "cursor")
                    child.SetSiblingIndex(i + 1);
            }
        }
    }
}