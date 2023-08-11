#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class UIButton : MonoBehaviour
    {
        [SerializeField] Text? label;
        [SerializeField] Button? button;

        public Text? Label => label;
        public Button? Button => button;

        /// <summary>
        /// クリックリスナーの追加
        /// </summary>
        /// <param name="call"></param>
        public void AddClickListener(UnityEngine.Events.UnityAction call)
        {
            if (button != null)
            {
                button.onClick.AddListener(call);
            }
        }

        /// <summary>
        /// ボタンの入力可否を設定
        /// </summary>
        /// <param name="flag"></param>
        public void SetInteractable(bool flag)
        {
            if (button != null)
            {
                button.interactable = flag;
            }
        }
    }

    /// <summary>
    /// 拡張機能
    /// </summary>
    public static class UIButtonExtensions
    {
        public static void AddClickListenerSafe(this UIButton? obj, UnityEngine.Events.UnityAction call)
        {
            if (obj != null)
            {
                obj.AddClickListener(call);
            }
        }

        public static void SetInteractableSafe(this UIButton? obj, bool flag)
        {
            if (obj != null)
            {
                obj.SetInteractable(flag);
            }
        }
    }
}