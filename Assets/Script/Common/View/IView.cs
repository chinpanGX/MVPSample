using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.View
{
    public interface IView
    {
        Canvas Canvas { get; }
        void Open();
        void Close();
    }
}