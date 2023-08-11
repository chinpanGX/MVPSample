using System.Collections;
using System.Collections.Generic;
using Common.Factory;
using Core;
using Scriptable;
using UnityEngine;

namespace Common.Director
{
    public class BootstrapDirector : MonoBehaviour
    {
        void Awake()
        {
            PrefabsFactory.Init();
        }
    }
}