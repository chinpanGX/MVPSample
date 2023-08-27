# nullable enable
using System.ComponentModel;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Common.UI;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;

namespace TT2023.Scene.Slot
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] List<UIText> texts = new();
        [SerializeField] int count = 0;
        List<Transform> slotNumbers = new();
        public bool IsActive { get; set; } = true;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < texts.Count; i++)
            {
                slotNumbers.Add(texts[i].transform);
            }
            RealStart();
        }

        public void RealStart()
        {
            Real().Forget();
        }

        async UniTaskVoid Real()
        {
            while (IsActive)
            {
                await UniTask.Delay(100);
                var lastIndex = count++ % 10;
                slotNumbers[lastIndex].SetAsFirstSibling();
            }
        }
    }
}