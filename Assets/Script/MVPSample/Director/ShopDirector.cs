#nullable enable
using System.Collections;
using System.Collections.Generic;
using Common.Director;
using Common.Presenter;
using MVPSample.Data;
using MVPSample.Model;
using MVPSample.Presenter;
using MVPSample.View;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace MVPSample.Director
{
    public class ShopDirector : SceneDirector
    {
        // Start is called before the first frame update
        void Start()
        {
            PlayerData.Instance.SetGold(1000);
            Push("Top");

            this.UpdateAsObservable().Subscribe(_ =>
            {
                base.Execute();
            }).AddTo(this.gameObject);
        }

        /// <summary>
        /// 画面遷移
        /// </summary>
        /// <param name="name"></param>
        public override void Push(string name)
        {
            IPresenter request = name switch
            {
                "Top" => new TopPresenter(this, TopModel.Create(), TopView.Create()),
                "ItemShop" => new ShopPresenter(this, ItemShopModel.Create(PlayerData.Instance), ShopView.Create()),
                "WeaponShop" => new ShopPresenter(this, WeaponShopModel.Create(PlayerData.Instance), ShopView.Create()),
                _ => null!
            };
            base.Set(request);
        }
    }
}