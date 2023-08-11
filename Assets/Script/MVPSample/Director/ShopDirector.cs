#nullable enable
using System.Collections;
using System.Collections.Generic;
using Common.Director;
using Common.Presenter;
using MVPSample.Model;
using MVPSample.Presenter;
using UnityEngine;

namespace MVPSample.Director
{
    public class ShopDirector : SceneDirector
    {
        // Start is called before the first frame update
        void Start()
        {
            Push("Top");
        }

        protected override void Update()
        {
            base.Update();
        }

        public override void Push(string name)
        {
            var request = name switch
            {
                "Top" => new TopPresenter(this, TopModel.Create(), TopView.Create()),
                _ => null!
            };
            base.Set(request);
        }
    }
}