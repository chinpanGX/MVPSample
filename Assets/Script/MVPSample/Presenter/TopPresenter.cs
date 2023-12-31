#nullable enable
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using Common.Director;
using Common.Presenter;
using Common.StateMachine;
using Common.UI;
using MVPSample.Model;
using MVPSample.View;
using UnityEngine;

namespace MVPSample.Presenter
{
    public class TopPresenter : IPresenter
    {
        IDirector Director { get; set; } = null!;
        TopModel Model { get; set; } = null!;
        TopView View { get; set; } = null!;
        StateMachine<TopPresenter> StateMachine { get; set; } = null!;

        public TopPresenter(IDirector director, TopModel model, TopView view)
        {
            Director = director;
            Model = model;
            View = view;

            StateMachine = new StateMachine<TopPresenter>(this);
            StateMachine.Change<StateInit>();
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

        # region ステートマシン
        class StateInit : StateMachine<TopPresenter>.State
        {
            public override void Begin(TopPresenter owner)
            {
                var view = owner.View;

                view.ItemShop.AddClickListenerSafe(() =>
                {
                    owner.Director.Push(Constants.ItemShop);
                });

                view.WeaponShop.AddClickListenerSafe(() =>
                {
                    owner.Director.Push(Constants.WeaponShop);
                });

                view.Debug.AddClickListenerSafe(() =>
                {

                });

                view.Push();
                view.Open();

                owner.StateMachine.Change<StateMain>();
            }
        }

        class StateMain : StateMachine<TopPresenter>.State
        {

        }

        /// <summary>
        /// ゲーム画面へ遷移
        /// </summary>
        class StateToGame : StateMachine<TopPresenter>.State
        {
            public override void Begin(TopPresenter owner)
            {

            }
        }
        # endregion ステートマシン
    }
}