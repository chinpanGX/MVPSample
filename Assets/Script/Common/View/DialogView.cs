#nullable enable
using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using Common.Factory;
using Common.UI;
using Core;
using DG.Tweening;
using UnityEngine;

namespace Common.View
{
    public class DialogView : MonoBehaviour, IView
    {
        public enum Type
        {
            Ok,
            YesNo,
        }

        [Serializable]
        public struct UITypeAccessory
        {
            [SerializeField] public GameObject? root;
            [SerializeField] public UIButton? button1;
            [SerializeField] public UIButton? button2;
        }

        [SerializeField] Canvas? canvas;
        [SerializeField] CanvasGroup? canvasGroup;
        [SerializeField] UIText? title;
        [SerializeField] UIText? message;
        [SerializeField] UITypeAccessory[] typeAccessories = null!;

        Type type;
        UITypeAccessory current;
        Tweener? tweener;

        static Screen? Screen => ComponentLocator.GetOrNull<Screen>();
        public Canvas? Canvas => canvas;

        #region 初期化/セットアップ
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
        #endregion 初期化/セットアップ

        #region アプリイベント
        public void Open() { }

        public void Open(Type type, string title, string message, Action<DialogView>? ok = null, Action<DialogView>? cancel = null)
        {
            Init(type, title, message, ok, cancel);
        }

        public void Close()
        {
            if (canvasGroup != null)
            {
                tweener = DOVirtual.Float(1f, 0f, 0.2f, v =>
                {
                    canvasGroup.alpha = v;
                }).SetLink(gameObject);
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
        #endregion アプリイベント

        #region MonoBehaviour
        void OnEnable()
        {
            tweener?.Kill();
            if (canvasGroup != null)
            {
                tweener = DOVirtual.Float(0f, 1f, 0.2f, v => { canvasGroup.alpha = v; });
            }
        }

        void OnDisable()
        {
            tweener?.Kill();
            tweener = null;
        }
        #endregion MonoBehaviour

        void Init(Type type, string title, string message, Action<DialogView>? ok, Action<DialogView>? cancel = null)
        {
            // 非表示にする
            foreach (var accessory in typeAccessories)
            {
                if (accessory.root != null)
                {
                    accessory.root.SetActive(false);
                }
            }

            this.type = type;

            // カレントタイプアクセサリを設定
            if (typeAccessories != null && (int)type < typeAccessories.Length)
            {
                current = typeAccessories[(int)type];
                if (current.root != null)
                {
                    current.root.SetActive(true);
                }
            }
            else
            {
                current = default;
            }

            // コンポーネントの設定
            this.title.SetTextSafe(title);
            this.message.SetTextSafe(message);
            if (current.button1 != null)
            {
                current.button1.AddClickListenerSafe(() => ok?.Invoke(this));
            }
            if (current.button2 != null)
            {
                current.button2.AddClickListenerSafe(() => cancel?.Invoke(this));
            }
        }

    }
}