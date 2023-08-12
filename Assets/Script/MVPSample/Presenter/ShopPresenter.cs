using System.Collections;
using System.Collections.Generic;
using Common.Director;
using Common.Presenter;
using Common.StateMachine;
using MVPSample.Model;
using MVPSample.View;
using UnityEngine;

namespace MVPSample.Presenter
{
    public class ShopPresenter : IPresenter
    {
        IDirector Director { get; set; } = null!;
        IShopModel Model { get; set; } = null!;
        IShopView View { get; set; } = null!;

        StateMachine<ShopPresenter> StateMachine { get; set; } = null!;

        public ShopPresenter(IDirector director, IShopModel model, IShopView view)
        {
            Director = director;
            Model = model;
            View = view;

            StateMachine = new StateMachine<ShopPresenter>(this);
            //StateMachine.Change<StateInit>();
        }

        public void Dispose()
        {
            Director = null!;

            View.Pop();
            View = null!;

            StateMachine.Dispose();
            StateMachine = null!;
        }

        public void Execute()
        {
            StateMachine.Execute();
        }

    }
}