#nullable enable
using System.Collections;
using System.Collections.Generic;
using Common.Director;
using Common.Presenter;
using Common.StateMachine;
using MVPSample.Model;
using MVPSample.View;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace MVPSample.Presenter
{
    public class ShopPresenter : IPresenter
    {
        int selectedItem = -1;
        IDirector Director { get; set; } = null!;
        IShopModel Model { get; set; } = null!;
        IShopView View { get; set; } = null!;

        StateMachine<ShopPresenter> StateMachine { get; set; } = null!;
        int SelectedItem => selectedItem;

        public ShopPresenter(IDirector director, IShopModel model, IShopView view)
        {
            Director = director;
            Model = model;
            View = view;

            StateMachine = new StateMachine<ShopPresenter>(this);
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
            if (StateMachine.IsState<StateMain>())
            {
                View.Process();
            }
        }

        # region イベント

        /// <summary>
        /// ノード選択時のイベント
        /// </summary>
        /// <param name="node"></param>
        void OnNodeButton(IShopNode? node)
        {
            var goods = Model.GetGoods(node?.UniqueId ?? -1);
            if (goods == null)
            {
                selectedItem = -1;
                View.SetCursor(-1);
                View.SetBuyActive(false);
                View.SetDesc(string.Empty);
                View.SetHaveNum(0);
            }
            else
            {
                selectedItem = goods.UniqueId;
                View.SetCursor(goods.UniqueId);
                View.SetBuyActive(true);
                View.SetDesc(goods.Name);
                var item = Model.GetItem(goods.Name);
                View.SetHaveNum(item?.Num ?? 0);
            }
        }

        /// <summary>
        /// 購入ボタンを押したときの処理
        /// </summary>
        void OnBuyButton()
        {
            if (selectedItem == -1) return;
            var element = Model.GetGoods(selectedItem);
            if (element == null) return;

            if (element.Price > Model.Gold)
            {
                OnBuyEvent(element);
            }
        }

        /// <summary>
        /// 購入イベント
        /// </summary>
        void OnBuyEvent(IShopElementModel element)
        {
            Model.SetGold(Model.Gold - element.Price);
            Model.AddItem(element);

            // 所持金の更新
            View.SetGold(Model.Gold);
            // 所持数の更新
            var item = Model.GetItem(element.Name);
            View.SetHaveNum(item?.Num ?? 0);
        }
        #endregion イベント

        #region ステートマシン
        class StateInit : StateMachine<ShopPresenter>.State
        {
            public override void Begin(ShopPresenter owner)
            {
                var view = owner.View;
                var model = owner.Model;

                // ショップ名
                view.SetTitle(model.Title);

                // 所持金
                view.SetGold(model.Gold);

                // 未選択状態
                owner.OnNodeButton(null);

                // 商品一覧
                foreach (var element in model.Goods)
                {
                    var node = view.AddNode();
                    if (node != null)
                    {
                        node.SetUniqueId(element.UniqueId);
                        node.SetName(element.Name);
                        node.SetPrice(element.Price);
                        node.SetButtonAction(owner.OnNodeButton);

                        if (owner.SelectedItem == -1)
                        {
                            owner.OnNodeButton(node);
                        }
                    }
                }

                view.SetBuyAction(owner.OnBuyButton);

                if (string.IsNullOrEmpty(model.Next) == false)
                {
                    view.SetNextAction(() =>
                    {
                        owner.StateMachine.Change<StateToNext>();
                    });
                }

                view.SetExitAction(() =>
                {
                    owner.StateMachine.Change<StateToTop>();
                });

                view.Push();
                view.Open();

                owner.StateMachine.Change<StateMain>();
            }
        }

        class StateMain : StateMachine<ShopPresenter>.State
        {

        }

        class StateToNext : StateMachine<ShopPresenter>.State
        {

        }

        class StateToTop : StateMachine<ShopPresenter>.State
        {
            public override void Begin(ShopPresenter owner)
            {
                owner.Director.Push(Constants.Top);
            }
        }
        #endregion ステートマシン
    }
}