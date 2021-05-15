using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "SORecept_", menuName = "SO/Recept", order = 2)]
    public class SORecept : ScriptableObject
    {
        public List<SOItem> NeedItems = new List<SOItem>();
        public SOItem ResultItem;

        [ReadOnly] public int ID;
    }
}