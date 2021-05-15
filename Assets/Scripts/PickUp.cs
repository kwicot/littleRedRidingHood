using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    private GameManager gameManager;
    public string KeyName;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        gameManager.Data.AddPickUpScript(this);
    }

    public void PickUpObject()
    {
        gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[41]);
        inventory.CreateItemByName(KeyName);
        gameManager.Data.PickUp(KeyName);
        gameObject.SetActive(false);

    }

    void CheckActive()
    {
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        gameManager.Data.AddPickUpScript(this);
        if(gameManager.Data.PickUpItemState != null)
            foreach (var item in gameManager.Data.PickUpItemState)
            {
                if (item.Key == KeyName)
                {
                    Debug.Log("Find");
                    if (item.Value == false)
                    {
                        Debug.Log("Disable");
                        gameObject.SetActive(false);
                    }
                }
            }
    }

    private void OnEnable()
    {
        CheckActive();
    }
}
