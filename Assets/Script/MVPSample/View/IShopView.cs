#nullable enable
using System.Collections;
using System.Collections.Generic;
using Common.View;
using UnityEngine;

namespace MVPSample.View
{
    public interface IShopView : IView
    {
        bool IsActive { get; }
        void Process();
        IShopNode? AddNode();
        void SetTitle(string title);
        void SetDesc(string desc);
        void SetGold(int gold);
        void SetHaveNum(int num);
        void SetCursor(int uniqueId);
        void SetBuyActive(bool flag);
        void SetBuyAction(System.Action action);
        void SetNextAction(System.Action action);
        void SetExitAction(System.Action action);
    }
}