using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    private GameManager gameManager;
    public int id;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    void Update()
    {
    }
    public void Click(GameObject gameObject)
    {
        if (gameManager.isActiveClick == true)
        {
            gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[17]);
            gameObject.SetActive(true);
            if (gameManager.MiniGameActive != 0)
            {
                gameManager.MiniGameActive2 = id;
                gameManager.MiniGameObject2 = gameObject;
            }
            else
            {
                gameManager.MiniGameActive = id;
                gameManager.MiniGameObject = gameObject;
            }
            if (gameManager.MiniGameActive != 0 && gameManager.MiniGameActive2 != 0)
            {
                gameManager.isActiveClick = false;
                if (gameManager.MiniGameActive == gameManager.MiniGameActive2)
                {
                    gameManager.AllRignt += 1;
                    gameManager.MiniGameActive = 0;
                    gameManager.MiniGameActive2 = 0;
                    gameManager.isActiveClick = true;
                    if(gameManager.AllRignt == 10)
                    {
                        StartCoroutine(Win());
                    }
                }
                else
                {
                    StartCoroutine(Delay());
                }
            }
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        gameManager.MiniGameActive = 0;
        gameManager.MiniGameActive2 = 0;
        gameManager.MiniGameObject.SetActive(false);
        gameManager.MiniGameObject2.SetActive(false);
        gameManager.isActiveClick = true;
    }
    private IEnumerator Win()
    {
        yield return new WaitForSeconds(0.5f);
        gameManager.MiniGamePanel.SetActive(false);
        gameManager.DoorTree.SetActive(false);
    }
}
