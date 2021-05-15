using System;
using Interfaces;
using Unity.Collections;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "SOItem_", menuName = "SO/Item", order = 0)]
    public class SOItem : ScriptableObject
    {
        [HideInInspector] public int ID;
         public GameObject Prefab;

        public string Name;

       
        
    }
}