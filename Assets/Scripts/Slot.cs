using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Inventory inventory;
    public GameObject[] Item;
    public Item item;
    public string KeyName;
    public int a;
    public int idItemSlot;

    void Awake()
    {
        if(transform.childCount > 0)
        {
            item = gameObject.GetComponentInChildren<Item>();
            idItemSlot = item.idItem;    
        } 
    }
    void Start()
    {
        KeyName += a + "Slot";
        var number = PlayerPrefs.GetInt(KeyName);
        if (number > 0)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    Instantiate(Item[number-1], inventory.slots[i].transform);
                    break;
                }
            }
        }
        if (PlayerPrefs.GetInt("ChoiseObject") > 0 && a == 0)
        {         
            InventoryItem();
        }
    }

    private void OnApplicationQuit ()
    {
        if (inventory.idActive > 0 && a == 0)
        {
            PlayerPrefs.SetInt("ChoiseObject", inventory.idActive);
        }
    }
    private void OnApplicationPause()
    {
        if(inventory.idActive > 0 && a == 0)
        {
            PlayerPrefs.SetInt("ChoiseObject", inventory.idActive);
        }
    }
    void InventoryItem()
    {
        var number = PlayerPrefs.GetInt("ChoiseObject");
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.Full[i] == false)
            {
                inventory.Full[i] = true;
                Instantiate(Item[number - 1], inventory.slots[i].transform);
                break;
            }
        }
    }
    void Update()
    {
        if (transform.childCount == 0)
        {
            inventory.Full[a] = false;
            idItemSlot = 0;
            PlayerPrefs.DeleteKey(KeyName);
        }
        else if(idItemSlot == 0)
        {
            item = gameObject.GetComponentInChildren<Item>();
            idItemSlot = item.idItem;
            PlayerPrefs.SetInt(KeyName, idItemSlot);
        }
    }
}
