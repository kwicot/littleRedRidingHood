using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    private GameManager gameManager;
    public string KeyName;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        var number = PlayerPrefs.GetInt(KeyName);
        if (number == 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void PickUpObject()
    {
        gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[41]);
        PlayerPrefs.SetInt(KeyName, 1);
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if(inventory.Full[i] == false)
            {
                inventory.Full[i] = true;
                Instantiate(slotButton, inventory.slots[i].transform);
                gameObject.SetActive(false);
                break;
            }
        }
    }

}
