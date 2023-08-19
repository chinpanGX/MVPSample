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

        protected virtual void Execute()
        {
            if (request != null)
            {
                presenter?.Dispose();
                presenter = request;
                request = null!;
            }

            presenter?.Execute();
        }

        protected void Set(IPresenter presenter)
        {
            request = presenter;
        }

        public virtual void Push(string name)
        {

        }
    }
}