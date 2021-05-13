using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePuzzleBeforeHouse : MonoBehaviour
{
    public GameObject[] Pos;
    public int pos = 1;
    public int UpCentreDown;
    private GameManager gameManager;
    private bool isPlay = true;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }
    public void ClcikPuzzle()
    {
        if (isPlay)
        {
            gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[42]);
            pos += 1;
            if (pos == 1)
            {
                Pos[0].SetActive(true);
                Pos[1].SetActive(false);
                Pos[2].SetActive(false);
            }
            else if (pos == 2)
            {
                Pos[0].SetActive(false);
                Pos[1].SetActive(true);
                Pos[2].SetActive(false);
            }
            else if (pos == 3)
            {
                Pos[0].SetActive(false);
                Pos[1].SetActive(false);
                Pos[2].SetActive(true);
            }
            else if (pos > 3)
            {
                Pos[0].SetActive(true);
                Pos[1].SetActive(false);
                Pos[2].SetActive(false);
                pos = 1;
            }
            if (UpCentreDown == 0)
            {
                gameManager.MiniGamePuzzleFinal = pos;
            }
            else if (UpCentreDown == 1)
            {
                gameManager.MiniGamePuzzleFinal1 = pos;
            }
            else if (UpCentreDown == 2)
            {
                gameManager.MiniGamePuzzleFinal2 = pos;
            }

            if (gameManager.MiniGamePuzzleFinal == 3 && gameManager.MiniGamePuzzleFinal1 == 2 && (gameManager.MiniGamePuzzleFinal2 == 0 || gameManager.MiniGamePuzzleFinal2 == 1))
            {
                isPlay = false;
                PlayerPrefs.SetInt("MiniGamePuzzleBeforeHouse", 1);
                StartCoroutine(TimeWin());
            }
        }
    }
    public IEnumerator TimeWin()
    {
        yield return new WaitForSeconds(0.3f);
        gameManager.WinMiniPuzzleGame();
    }
}
