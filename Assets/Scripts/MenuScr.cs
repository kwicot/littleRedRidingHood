using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScr : MonoBehaviour
{
    public GameObject[] EngVer;
    public GameObject[] RusVer;
    public GameObject StartPanel;
    public GameObject Menu;
    private GameManager gameManager;
    public GameObject[] Languages;
    private int saveLanguages;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        if (PlayerPrefs.GetInt("Play") == 1)
        {
            StartPanel.SetActive(true);
            PlayerPrefs.SetInt("Play", 0);
            Menu.SetActive(false);
        }
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
        if(saveLanguages == 1)
        {
            PlayerPrefs.SetInt("Ver", 1);
        }
        PlayerPrefs.SetInt("Play", 1);
        PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
        PlayerPrefs.SetInt("PlayStartMusic", 1);
        gameManager.Data.NewGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResumeGame(GameObject ResumeGame)
    {
        ResumeGame.SetActive(true);
        Menu.SetActive(false);
        gameManager.MusicPlay(gameManager.MusicBG);
        gameManager.Data.LoadData();
    }
}
