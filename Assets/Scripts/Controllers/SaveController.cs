using System;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class SaveController : MonoBehaviour
    {
        public GameObject objectsToSave;
        public Inventory Inventory;
        private GameManager manager;
        
        

        private Dictionary<string, bool> ObjectsSate = new Dictionary<string, bool>();
        private HashSet<GameObject> AllObjects;

        private void Start()
        {
            SetupObjectsStates();
            manager = FindObjectOfType<GameManager>();
        }

        private int id = 0;
        void SetupObjectsStates()
        {
            AllObjects = GetChilds(objectsToSave);
            ObjectsSate.Clear();
            foreach (var obj in AllObjects)
            {
                obj.name += "_" + id;
                ObjectsSate.Add(obj.name,obj.activeSelf);
                id++;
            }
            SetupButtonsAction();
        }

        void ReloadStates()
        {
            foreach (var obj in AllObjects)
            {
                try
                {
                    var objname = obj.name;
                    var active = obj.activeSelf;
                    ObjectsSate[objname] = active;
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }
        }

        void SetupButtonsAction()
        {
            foreach (var obj in AllObjects)
            {
                if (obj.TryGetComponent(out Button btn))
                {
                    var find = false;
                    var listeners = btn.onClick.GetPersistentEventCount();
                    for (int i = 0; i < listeners; i++)
                    {
                        if (btn.onClick.GetPersistentMethodName(i) == "Save") find = true;
                    }
                    if(!find) btn.onClick.AddListener(()=>Save());
                }
            }
        }

        HashSet<GameObject> GetChilds(GameObject obj)
        {
            HashSet<GameObject> objs = new HashSet<GameObject>();
            objs.Add(obj);
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                if (obj.transform.GetChild(i).childCount > 0)
                {
                    HashSet<GameObject> objectsInChild = GetChilds(obj.transform.GetChild(i).gameObject);
                    foreach (var o in objectsInChild)
                        objs.Add(o);
                }
                else objs.Add(obj.transform.GetChild(i).gameObject);
            }

            return objs;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)) Save();
            if (Input.GetKeyDown(KeyCode.Alpha2)) Load();
        }

        public void Save()
        {
           ReloadStates();
           SaveInventory();
           PersistentCache.Save("Objects", ObjectsSate);
           Debug.Log("Saved");

        }

        public void Load()
        {
            Dictionary<string, bool> state = PersistentCache.TryLoad<Dictionary<string, bool>>("Objects");
            foreach (var obj in AllObjects)
            {
                try
                {
                    var objname = obj.name;
                    var active = state[objname];
                    obj.SetActive(active);
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }
            manager.MusicPlay(manager.MusicBG);
            LoadInventory();
        }

        void SaveInventory()
        {
            List<ItemData> itemsData = new List<ItemData>();
            List<ItemController> items = Inventory.GetItems();
            foreach (var item in items)
            {

                try
                {
                    ItemData data = new ItemData()
                    {
                        ItemName = item.MainData.Name,
                        OnHand = false
                    };
                    itemsData.Add(data);
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }

            Slot hand = Inventory.HandSlot;
            if (hand.selectedItemController != null)
            {
                ItemData data = new ItemData()
                {
                    ItemName = hand.selectedItemController.MainData.Name,
                    OnHand = true
                };
                itemsData.Add(data);
            }

            PersistentCache.Save("Inventory", itemsData);
        }

        void LoadInventory()
        {
            List<ItemData> itemsData = PersistentCache.TryLoad<List<ItemData>>("Inventory");
            foreach (var item in itemsData)
            {
                try
                {
                    if (item.OnHand)
                    {
                        Inventory.CreateItemByName(item.ItemName,out ItemController handItem,false);
                        Inventory.Equipt(handItem);
                    }
                    else
                    {
                        Inventory.CreateItemByName(item.ItemName);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }
            Save();
        }

        public void Clear()
        {
            
        }

        private void OnApplicationQuit()
        {
            Save();
            Debug.Log("Saved");
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            //Save();
        }

        public bool HasData()
        {
            if (PersistentCache.HasKey("Inventory") && PersistentCache.HasKey("Objects")) return true;
            else return false;
        }
    }
}