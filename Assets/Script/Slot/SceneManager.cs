#nullable enable
using System.Collections;
using System.Collections.Generic;
using Common.UI;
using UnityEngine;

namespace TT2023.Scene.Slot
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] UIButton? button;
        [SerializeField] Slot[] slots = new Slot[3];

        // Start is called before the first frame update
        void Start()
        {
            var index = 0;

            button.AddClickListenerSafe(() =>
            {
                if (index >= slots.Length) return;

                Debug.Log(index);
                slots[index].IsActive = false;
                index++;

            });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}