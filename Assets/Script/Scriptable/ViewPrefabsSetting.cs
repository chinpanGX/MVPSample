using System.Collections;
using System.Collections.Generic;
using MVPSample.View;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu()]
    public class ViewPrefabsSetting : ScriptableObject
    {
        [Header("プレハブの設定")]
        [SerializeField] TopView topViewPrefabs;

        //[SerializeField]

        public TopView TopViewPrefabs => topViewPrefabs;
    }
}
