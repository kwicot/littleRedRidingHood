using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "SOItemsHolder", menuName = "SO/Items holder", order = 1)]
    public class SOItemsHolder : ScriptableObject
    {
        [SerializeField]private List<SOItem> ItemsList = new List<SOItem>();
       [SerializeField] private List<SORecept> ReceptsList = new List<SORecept>();
        public int ItemsCount => ItemsList.Count;
        public int ReceptsCount => ReceptsList.Count;

        private void OnValidate()
        {
            int i = 0;
            foreach (var soItem in ItemsList)
            {
                soItem.ID = i;
                i++;
            }

            i = 0;
            foreach (var soRecept in ReceptsList)
            {
                soRecept.ID = i;
                i++;
            }
        }

        public SOItem this[int index]
        {
            get
            {
                try
                {
                    var item = ItemsList[index];
                    return item;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return null;
            }
        }

        public List<SORecept> GetAllRecepts()
        {
            return ReceptsList;
        }

        public List<SORecept> GetReceptsWithItem(SOItem item)
        {
            List<SORecept> recepts = new List<SORecept>();
            foreach (var soRecept in ReceptsList)
            {
                foreach (var needItem in soRecept.NeedItems)
                {
                    if(needItem.Name == item.Name) recepts.Add(soRecept);
                }
            }

            return recepts;
        }

        public List<SOItem> GetNeedItemToCraftRecept(SORecept recept)
        {
            List<SOItem> needItems = new List<SOItem>();
            foreach (var soRecept in ReceptsList)
            {
            }

            return needItems;
        }

        public SOItem GetItemByName(string Name)
        {
            foreach (var soItem in ItemsList)
            {
                if (soItem.Name == Name) return soItem;
            }

            return null;
        }

        
    }
    
}