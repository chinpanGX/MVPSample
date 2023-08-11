#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Presenter;

namespace Common.Director
{
    public class SceneDirector : MonoBehaviour, IDirector
    {
        IPresenter? presenter = null;
        IPresenter? request = null;

        protected virtual void Update()
        {
            if (request != null)
            {
                presenter?.Dispose();
                presenter = request;
                request = null!;
            }

            presenter?.Execute();
        }

        public virtual void Push(string name)
        {

        }
    }
}