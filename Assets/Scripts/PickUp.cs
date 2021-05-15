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
    }

    public void PickUpObject()
    {
        gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[41]);
        inventory.CreateItemByName(KeyName);
        Destroy(gameObject);

    }
}
