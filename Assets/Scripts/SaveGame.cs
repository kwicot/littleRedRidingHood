using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameObject[] GameObjects;
    public string KeyName;

    void Start()
    {
        var number = PlayerPrefs.GetInt(KeyName);
        if (number == 1)
        {
            for (int i = 0; i < GameObjects.Length; i++)
            {
                if (GameObjects[i].activeSelf == true)
                {
                    GameObjects[i].SetActive(false);
                }
                else
                {
                    GameObjects[i].SetActive(true);
                }
            }
        }
    }
}
