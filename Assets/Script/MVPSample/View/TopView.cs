#nullable enable
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.View;
using Common.UI;
using Core;
using Scriptable;
using Common.Factory;

namespace MVPSample.View
{
    public class TopView : MonoBehaviour, IView
    {
        [SerializeField] Canvas? canvas;
        [SerializeField] UIButton? itemShop;
        [SerializeField] UIButton? weaponShop;
        [SerializeField] UIButton? debug;

        #region プロパティ
        static Common.View.Screen? Screen => ComponentLocator.GetOrNull<Common.View.Screen>();
        public Canvas? Canvas => canvas;
        public UIButton? ItemShop => itemShop;
        public UIButton? WeaponShop => WeaponShop;
        public UIButton? Debug => debug;
        public bool IsActive { get; private set; } = false;
        #endregion プロパティ

        # region 生成/セットアップ
        public static TopView Create()
        {
            TopView view = PrefabsFactory.CreateTopView();
            view.Init();
            return view;
        }

        public void Push()
        {
            var screen = Screen;
            if (screen != null)
            {
                screen.Push(this);
            }
        }

        public void Pop()
        {
            var screen = Screen;
            if (screen != null)
            {
                screen.Pop();
            }
        }
        # endregion 生成/セットアップ

        # region アプリイベント
        public void Open()
        {
            gameObject.SetActive(true);
            IsActive = true;
        }

        public void Close()
        {
            Destroy(gameObject);
            IsActive = false;
        }
        # endregion アプリイベント

        # region ヘルパー関数
        void Init()
        {
            gameObject.SetActive(false);
        }
        # endregion
    }
}