using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScr : MonoBehaviour
{
    public SaveController SaveController;
    public GameObject[] EngVer;
    public GameObject[] RusVer;
    public GameObject StartPanel;
    public GameObject Menu;
    private GameManager gameManager;
    public GameObject[] Languages;
    public GameObject Privacy;
    private int saveLanguages;
    void Start()
    {
        if (PlayerPrefs.GetInt("Privacy") == 0)
        {
            Privacy.SetActive(true);
            PlayerPrefs.SetInt("Privacy", 1);
        }
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        if (PlayerPrefs.GetInt("Ver") == 0)
        {
            EnglisVersion();
        }
        else
        {
            RussiaVersion();
        }
    }

    public void RussiaVersion()
    {
        PlayerPrefs.SetInt("Ver", 1);
        for (int i = 0; i < EngVer.Length; i++)
        {
            EngVer[i].SetActive(false);
        }
        for (int i = 0; i < RusVer.Length; i++)
        {
            RusVer[i].SetActive(true);
        }
        Languages[0].SetActive(true);
        Languages[1].SetActive(false);
        saveLanguages = 1;
    }
    public void EnglisVersion()
    {
        PlayerPrefs.SetInt("Ver", 0);
        for (int i = 0; i < RusVer.Length; i++)
        {
            RusVer[i].SetActive(false);
        }
        for (int i = 0; i < EngVer.Length; i++)
        {
            EngVer[i].SetActive(true);
        }
        Languages[0].SetActive(false);
        Languages[1].SetActive(true);
        saveLanguages = 0;
    }
    public void Play()
    {
        PlayerPrefs.DeleteAll();
        Menu.SetActive(false);
        StartPanel.SetActive(true);
        if(saveLanguages == 1)
        {
            PlayerPrefs.SetInt("Ver", 1);
        }
        SaveController.Clear();

        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResumeGame(GameObject ResumeGame)
    {
        if (SaveController.HasData())
        {
            Menu.SetActive(false);
            SaveController.Load();
        }
        else Play();
    }
}
