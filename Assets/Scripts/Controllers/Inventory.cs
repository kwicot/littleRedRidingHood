using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [SerializeField] private List<ItemController> ItemsList = new List<ItemController>();
    [SerializeField] private SOItemsHolder Holder;
    public Slot[] SlotsUI;
    public Slot HandSlot;
    private GameManager manager;

    public bool CraftMode = false;

    public int ItemsCount => ItemsList.Count;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public ItemController this[int index]
    {
        get
        {
            return ItemsList[index];
        }
        set
        {
            ItemsList[index] = value;
        }
    }
    public void TryCraft(ItemController itemController)
    {
        Debug.Log("Try craft method");
        if (HandSlot.selectedItemController != null)
        {
            Debug.Log("Have item in hand");
            List<SORecept> recepts = Holder.GetReceptsWithItem(HandSlot.selectedItemController.MainData);
            Debug.Log(recepts.Count);
            foreach (var soRecept in recepts)
            {
                Debug.Log(soRecept.NeedItems.Count);
                foreach (var needItem in soRecept.NeedItems)
                {
                    if (needItem.Name == itemController.MainData.Name)
                    {
                        Craft(soRecept);
                        return;
                    }
                }
            }
        }
    }

    void Craft(SORecept recept)
    {
        Debug.Log("Craft method");
        //TODO Craft
        for (int i = ItemsList.Count-1; i >= 0; i--)
        {
            var item = ItemsList[i];
            foreach (var _item in recept.NeedItems)
            {
                if(item.MainData.Name == _item.Name)
                {
                    RemoveItem(item.MainData.Name);
                    break;
                }
            }
        }
        RemoveItem(HandSlot.selectedItemController.name);
        CreateItemByName(recept.ResultItem.Name);


        CraftMode = false;
    }

    public void AddItem(ItemController itemController, bool WithSave = true)
    {
        //Проверка есть ли такой предмет
        foreach (var _item in ItemsList)
            if(_item.MainData.Name == itemController.MainData.Name)
            {
                Debug.Log("Item not found in dateBase");
                return;
            }
        
        if(HandSlot.selectedItemController != null)
            if (HandSlot.selectedItemController.MainData.Name == itemController.MainData.Name)
            {
                Debug.Log("This item in hand");
                return;
            }
        
        
        //Проверка наличия места
        if (ItemsList.Count >= 15)
            throw new Exception("Нет места");
        
        
        //Добавление предмета и установка в первый пустой слот
        ItemsList.Add(itemController);
        for (int i = 0; i < SlotsUI.Length; i++)
        {
            if (SlotsUI[i].selectedItemController == null)
            {
                itemController.SetSlot(SlotsUI[i]);
                break;
            }
        }


        Debug.Log("Item added successful");
    }

    public void RemoveItem(ItemController item)
    {
        if (HandSlot.selectedItemController != null && HandSlot.selectedItemController.MainData.Name == item.MainData.Name) HandSlot.selectedItemController = null;
        Destroy(item.gameObject);
        RemoveNulls();
    }
    public void RemoveItem(string name)
    {
        if (HandSlot.selectedItemController != null && HandSlot.selectedItemController.name == name)
        {
            Destroy(HandSlot.selectedItemController.gameObject);
            HandSlot.selectedItemController = null;
        }
        RemoveNulls();
        foreach (var itemController in ItemsList)
        {
            if(itemController.MainData.Name == name)
            {
                DestroyImmediate(itemController.gameObject);
                return;
            }
        }
    }
    public void RemoveItem(SOItem item)
    {
        foreach (var itemController in ItemsList)
        {
            if (itemController.MainData == item)
            {
                if (HandSlot.selectedItemController != null && HandSlot.selectedItemController == itemController) HandSlot.selectedItemController = null;
                Destroy(itemController.gameObject);
            }
        }

        RemoveNulls();
    }
    

    private void RemoveNulls()
    {
        for (int i = ItemsList.Count-1; i >=0; i--)
        {
            if (ItemsList[i] == null) ItemsList.RemoveAt(i);
        }
    }

    public void Equipt(ItemController itemController)
    {
        //Проверка наличия предмета в руке
        if (HandSlot.selectedItemController != null)
        {
            if (HandSlot.selectedItemController.MainData.Name == itemController.MainData.Name)
            {
                Unequipt();
                Debug.Log("This item was been om hand and removed");
                ChangeIcon();
                return;
            }
            else
                Unequipt();
        }
        

        //Поиск предмета в инвентаре
        for (int i = 0; i < ItemsList.Count; i++)
        {
            foreach (var slot in SlotsUI)
            {
                if (slot.selectedItemController != null)
                    if (slot.selectedItemController.MainData.Name == itemController.MainData.Name)
                        slot.selectedItemController = null;
            }

            if (ItemsList[i].MainData.Name == itemController.MainData.Name)
            {
                //Установка предмета
                ItemsList.RemoveAt(i);
                itemController.SetSlot(HandSlot);
                HandSlot.selectedItemController = itemController;
                Debug.Log("Equipt");
                ChangeIcon();
                return;
            }
        }
        Debug.Log("Not find");
    }

    public void Unequipt(bool WithRemove = false)
    {
        if(HandSlot.selectedItemController == null) return; //Проверка на наличие предмета в руке
        if (ItemsList.Count >= 15) throw new Exception("Нет места"); //Проверка на наличия места в рюкзаке

        if (!WithRemove)
        {

            //Find empty slot in inventory
            Slot emptySlot = SlotsUI[0];
            foreach (var _slot in SlotsUI)
                if (_slot.selectedItemController == null)
                {
                    emptySlot = _slot;
                    break;
                }

            ItemController item = HandSlot.selectedItemController;
            HandSlot.selectedItemController = null;
            AddItem(item);
            item.SetSlot(emptySlot);
        }
        else
        {
            RemoveItem(HandSlot.selectedItemController);
        }
        HandSlot.selectedItemController = null;
        ChangeIcon();
    }
    public void CreateItemById(int id, out ItemController controller)
    {
        SOItem item;

        for (int i = 0; i < Holder.ItemsCount; i++)
        {
            item = Holder[i];
            if (item.ID == id)
            {
                var obj = Instantiate(item.Prefab);
                obj.GetComponent<ItemController>().MainData = item;
                AddItem(obj.GetComponent<ItemController>());
                controller = obj.GetComponent<ItemController>();
                return;
            }
        }

        controller = null;
    }
    public void CreateItemByName(string name, out ItemController controller,bool WithSave = true)
    {
        SOItem item;

        for (int i = 0; i < Holder.ItemsCount; i++)
        {
            item = Holder[i];
            if (item.Name == name)
            {
                var obj = Instantiate(item.Prefab);
                obj.GetComponent<ItemController>().MainData = item;
                AddItem(obj.GetComponent<ItemController>(), WithSave);
                controller = obj.GetComponent<ItemController>();
                return;
            }
        }

        controller = null;
    }
    public void CreateItemByName(List<string> names)
    {
        SOItem item;
        foreach (var name in names)
        {
            for (int i = 0; i < Holder.ItemsCount; i++)
            {
                item = Holder[i];
                if (item.Name == name)
                {
                    var obj = Instantiate(item.Prefab);
                    obj.GetComponent<ItemController>().MainData = item;
                    AddItem(obj.GetComponent<ItemController>(), false);
                }
            }
        }
    }
    public void CreateItemByName(string name)
    {
        SOItem item;

        for (int i = 0; i < Holder.ItemsCount; i++)
        {
            item = Holder[i];
            if (item.Name == name)
            {
                var obj = Instantiate(item.Prefab);
                var cont = obj.GetComponent<ItemController>();
                cont.MainData = item;
                AddItem(cont);
                Debug.Log("Item created successful");
                return;
            }
        }
        Debug.Log("Fail create, not found name " + name);
    }

    public bool CheckHandItemName(string name)
    {
        if (HandSlot.selectedItemController)
        {
            if (HandSlot.selectedItemController.MainData.Name == name) return true;
            else return false;
        }

        return false;
    }

    public List<ItemController> GetItems()
    {
        return ItemsList;
    }

    void ChangeIcon()
    {
        Image img = manager.inventoryBttn1.transform.GetChild(0).GetComponent<Image>();
        if (HandSlot.selectedItemController != null)
        {
            img.gameObject.SetActive(true);
            img.sprite = HandSlot.selectedItemController.GetComponent<Image>().sprite;
        }
        else
            img.gameObject.SetActive(false);
    }
    
}
