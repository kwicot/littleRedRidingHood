using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private GameManager gameManager;
    private Inventory inventory;
    public GameObject choiceItemSlot;
    public GameObject icon;
    public GameObject inventoryBttn;
    public GameObject CraftObject;
    public bool isMain = false;
    public bool isCraftObject = false;
    public int idItem;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    void Update()
    {
        if (inventory.mailIsFull)
        {
            choiceItemSlot = inventory.mainSlot.transform.GetChild(0).gameObject;
        }
    }

    public void ChoiceItems()
    {
        if (inventory.mailIsFull == false)
        {
            transform.position = inventory.mainSlot.transform.position;
            transform.SetParent(inventory.mainSlot.transform);
            Instantiate(icon, inventory.inventoryBttn.transform);
            isMain = true;
            inventory.mailIsFull = true;
            inventory.idActive = idItem;
        }
        else if (inventory.mailIsFull == true && isMain)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    transform.position = inventory.slots[i].transform.position;
                    transform.SetParent(inventory.slots[i].transform);
                    break;
                }
            }
            isMain = false;
            inventoryBttn = GameObject.FindGameObjectWithTag("IconItem");
            Destroy(inventoryBttn);
            inventory.mailIsFull = false;
            inventory.idActive = 0;
        }
        else if ((gameManager.isCraft && isCraftObject) && inventory.idActive == 16 || inventory.idActive == 17) // Секатор 
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    Instantiate(CraftObject, inventory.slots[i].transform);
                    break;
                }
            }
            Craft();
        }
        else if ((gameManager.isCraft && isCraftObject) && inventory.idActive == 7 || inventory.idActive == 28) // Топор
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    Instantiate(CraftObject, inventory.slots[i].transform);
                    break;
                }
            }
            Craft();
        }
        else if ((gameManager.isCraft && isCraftObject) && inventory.idActive == 34 || inventory.idActive == 39) // Дымарь
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    Instantiate(CraftObject, inventory.slots[i].transform);
                    break;
                }
            }
            Craft();
        }
        else if ((gameManager.isCraft && isCraftObject) && inventory.idActive == 33 || inventory.idActive == 42) // Динамит
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    Instantiate(CraftObject, inventory.slots[i].transform);
                    break;
                }
            }
            Craft();
        }
        else if ((gameManager.isCraft && isCraftObject) && inventory.idActive == 45 || inventory.idActive == 37) // Фонарь
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    Instantiate(CraftObject, inventory.slots[i].transform);
                    break;
                }
            }
            Craft();
        }
        else if ((gameManager.isCraft && isCraftObject) && inventory.idActive == 62 || inventory.idActive == 51) // Удочка 
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    Instantiate(CraftObject, inventory.slots[i].transform);
                    break;
                }
            }
            Craft();
        }
        else if ((gameManager.isCraft && isCraftObject) && inventory.idActive == 61 || inventory.idActive == 65) // Острая коса
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.Full[i] == false)
                {
                    inventory.Full[i] = true;
                    Instantiate(CraftObject, inventory.slots[i].transform);
                    break;
                }
            }
            Craft();
        }
        else
        {
            gameManager.isCraft = false;
            gameManager.DownCraftBttn.SetActive(false);
        }
    }
    void Craft()
    {
        inventoryBttn = GameObject.FindGameObjectWithTag("IconItem");
        inventory.mailIsFull = false;
        inventory.idActive = 0;
        gameManager.isCraft = false;
        gameManager.DownCraftBttn.SetActive(false);
        Destroy(gameObject);
        Destroy(inventoryBttn);
        Destroy(choiceItemSlot);
    }
}
