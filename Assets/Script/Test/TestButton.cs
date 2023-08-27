using System.Collections;
using System.Collections.Generic;
using Common.UI;
using UnityEngine;

namespace Test
{

    public class TestButton : MonoBehaviour
    {
        [SerializeField] List<UIButton> buttons;
        // Start is called before the first frame update
        void Start()
        {
            foreach (UIButton button in buttons)
            {
                button.AddClickListenerSafe(() => Debug.Log("クリック"));
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (UIButton button in buttons)
            {
                //button.Button.onClick.Invoke();

                //button.Button.onClick.Invoke();
            }
        }
    }
}