using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Presenter
{
    public interface IPresenter : IDisposable
    {
        void Execute();
    }
}