#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using Common.UI;
using UnityEngine;
using DG.Tweening;
using Core;

namespace MVPSample.View
{
    public class ShopView : MonoBehaviour, IShopView
    {
        [SerializeField] Canvas? canvas;
        [SerializeField] RectTransform window;
        [SerializeField] RectTransform cursor;
        [SerializeField] ShopNode node;
        [SerializeField] UIText? title;
        [SerializeField] UIText? gold;
        [SerializeField] UIButton? buy;
        [SerializeField] UIButton? exit;

        List<ShopNode?> nodes = new();
        Tweener? tweenr = null;

        # region プロパティ
        static Common.View.Screen? Screen => ComponentLocator.GetOrNull<Common.View.Screen>();
        public Canvas? Canvas => canvas;
        public RectTransform? Window => window;
        public bool IsActive { get; private set; } = false;
        # endregion プロパティ

        # region 生成/初期化/破棄
        /// <summary>
        /// 生成
        /// </summary>
        public static IShopView Create()
        {
            return new ShopView();
        }

        /// <summary>
        /// ノードの追加
        /// </summary>
        /// <returns></returns>
        public IShopNode? AddNode()
        {
            if (node == null) return null;
            var newNode = Instantiate(node, node.transform.parent, false);
            nodes.Add(newNode);
            return newNode;
        }

        public void Push()
        {
            if (Screen != null)
            {
                Screen.Push(this);
            }
        }

        public void Pop()
        {
            if (Screen != null)
            {
                Screen.Pop();
            }
        }
        # endregion 生成/初期化/破棄

        # region MonoBehaviourイベント
        void OnDisable()
        {
            if (tweenr != null)
            {
                tweenr.Kill();
            }
            tweenr = null;
        }
        # endregion MonoBehaviourイベント

        # region アプリイベント
        // 更新処理
        public void Process()
        {

        }

        /// <summary>
        /// 開く
        /// </summary>
        public void Open()
        {
            gameObject.SetActive(true);

            if (window != null)
            {
                tweenr = DOVirtual.Float(0f, 1f, 0.1f, v =>
                {
                    window.localScale = new Vector3(v, v, 1.0f);
                }).OnComplete(() => Opened());
            }
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        public void Close()
        {
            if (!IsActive) return;

            if (window != null)
            {
                tweenr = DOVirtual.Float(1f, 0f, 0.1f, v =>
                {
                    window.localScale = new Vector3(v, v, 1.0f);
                }).OnComplete(() => Closed());
            }
            else
            {
                Closed();
            }
        }
        # endregion アプリイベント

        # region 取得/設定
        /// <summary>
        /// ノードの取得
        /// </summary>
        public ShopNode? GetNode(int uniqueId)
        {
            foreach (var node in nodes)
            {
                if (node?.UniqueId == uniqueId)
                {
                    return node;
                }
            }
            return null;
        }

        /// <summary>
        /// タイトルの設定
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            this.title.SetTextSafe(title);
        }

        /// <summary>
        /// 所持金の設定
        /// </summary>
        /// <param name="gold"></param>
        public void SetGold(int gold)
        {
            this.gold.SetTextSafe($"{gold}");
        }

        /// <summary>
        /// カーソルの設定
        /// </summary>
        public void SetCursor(int uniqueId)
        {
            if (cursor == null) return;
            var node = GetNode(uniqueId);
            if (node == null)
            {
                cursor.gameObject.SetActive(false);
            }
            else
            {
                cursor.gameObject.SetActive(true);
                cursor.SetParent(node.transform, false);
                cursor.anchoredPosition = Vector3.zero;
            }
        }

        /// <summary>
        /// ボタンのON/OFF
        /// </summary>
        public void SetBuyAction(bool flag)
        {
            buy.SetInteractableSafe(flag);
        }

        /// <summary>
        /// 購入ボタンのアクション
        /// </summary>
        public void SetBuyAction(Action action)
        {
            buy.AddClickListenerSafe(() => action());
        }


        public void SetDesc(string desc) { }

        public void SetExitAction(Action action) { }


        public void SetHaveNum(int num) { }

        public void SetNextAction(Action action) { }
        # endregion 取得/設定

        # region ヘルパー関数
        /// <summary>
        /// 初期化
        /// </summary>
        void Init()
        {

        }

        /// <summary>
        /// Viewが開いたとき
        /// </summary>
        void Opened()
        {
            IsActive = true;
        }

        /// <summary>
        /// Viewが閉じられたとき
        /// </summary>
        void Closed()
        {
            Destroy(gameObject);
            IsActive = false;
        }
        # endregion ヘルパー関数
    }
}