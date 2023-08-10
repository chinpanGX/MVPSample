using System.Collections;
using System.Collections.Generic;
using TT2023.Common;
using UniRx;
using UnityEngine;

public class PreventHits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        IMessageReceiver<SampleEvent> sub = MessageBroker.Default.GetSubscriber<SampleEvent>();

        sub.Subscribe(x => 
        {
            this.gameObject.SetActive(x.onEvent);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
