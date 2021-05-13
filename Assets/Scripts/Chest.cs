using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public int number1, number2, number3, number4;
    public Text Text1, Text2, Text3, Text4;
    public GameObject Openchest;
    public GameManager gameManager;
    private Inventory inventory;
    public GameObject Kod;
    private Item Item;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();
        Item = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Item>();
    }
    public void NumberCod1()
    {
        number1++;
        if(number1 > 9)
        {
            number1 = 0;
        }
        Text1.text = "" + number1;
        gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[2]);
    }
    public void NumberCod2()
    {
        number2++;
        if (number2 > 9)
        {
            number2 = 0;
        }
        Text2.text = "" + number2;
        gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[2]);

    }
    public void NumberCod3()
    {
        number3++;
        if (number3 > 9)
        {
            number3 = 0;
        }
        Text3.text = "" + number3;
        gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[2]);

    }
    public void NumberCod4()
    {
        number4++;
        if (number4 > 9)
        {
            number4 = 0;
        }
        Text4.text = "" + number4;
        gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[2]);

    }

    void Update()
    {
        if(number1 == 7 && number2 == 1 && number3 == 6 && number4 == 3)
        {
            if(inventory.idActive == 14)
            {
                Kod = GameObject.FindGameObjectWithTag("IconItem");
                Destroy(Kod);
                Destroy(Item.choiceItemSlot);
                inventory.idActive = 0;
                inventory.mailIsFull = false;
            }
            else if(inventory.idActive != 14)
            {
                Kod = GameObject.FindGameObjectWithTag("Kod");
                Destroy(Kod);
            }
            Openchest.SetActive(true);
            gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[1]);
            number1 = 8;
            PlayerPrefs.SetInt("ChestLivinRoom", 1);
        }
    }
}
