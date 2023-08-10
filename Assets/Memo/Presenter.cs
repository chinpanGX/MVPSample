using System.Collections;
using System.Collections.Generic;
using TT2023.Common;
using UniRx;
using UnityEngine;

public class Presenter
{
    Manager manager;
    Model model;
    View view;

    public Presenter(Manager manager, Model model, View view)
    {
        this.manager = manager;
        this.model = model;
        this.view = view;
    }

    public void Start()
    {
        var data = model.Add(new MemoData("sample1", "SAMPLE1"));
        view.AddMemo(data.data, data.count);

        IMessagePublisher<SampleEvent> pub = MessageBroker.Default.GetPublisher<SampleEvent>();

        view.Button.onClick.AddListener(() => 
        {
            pub.Publish(new SampleEvent(true));
            
            var data = model.Add(new MemoData());
            view.AddMemo(data.data, data.count);
        });
    }


    private void Update()
    {
            
    }
}
