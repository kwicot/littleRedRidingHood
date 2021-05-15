using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;
using UnityEngine.UI;

public class ChestCave : MonoBehaviour
{
    public int number1, number2, number3, number4;
    public Text Text1, Text2, Text3, Text4;
    public GameObject Openchest;
    public GameManager gameManager;
    private Inventory inventory;
    public GameObject Kod;
    private ItemController itemController;


    public SOItem QuestItem;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();
        itemController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ItemController>();
    }

    public void NumberCod1()
    {
        number1++;
        if (number1 > 9)
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
        if (number1 == 4 && number2 == 9 && number3 == 1 && number4 == 6)
        {
            Openchest.SetActive(true);
            inventory.RemoveItem(QuestItem);
        }
        else
        {
            Openchest.SetActive(false);
        }
    }
}
