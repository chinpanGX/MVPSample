using System.Collections;
using System.Collections.Generic;
using Common.Director;
using Common.Presenter;
using Common.StateMachine;
using MVPSample.Model;
using UnityEngine;

namespace MVPSample.Presenter
{
    public class TopPresenter : IPresenter
    {
        IDirector Director { get; set; } = null!;
        TopModel Model { get; set; } = null!;

        StateMachine<TopPresenter> StateMachine { get; set; } = null!;


        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}