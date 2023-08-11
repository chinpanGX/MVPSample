using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Director
{
    public interface IDirector
    {
        void Push(string name);
    }
}