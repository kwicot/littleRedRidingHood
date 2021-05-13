using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStone : MonoBehaviour
{
    public bool isRotate;

    public float mainTime = 5;      //время интерполяции
    public float elapsedTime;
    public float mainValue;
    public float minValue = 0;       //стартовая позиция
    public float maxValue = 0;  //конечная позиция
    private bool isPlay = true;
    private GameManager gameManager;
    public GameObject Panel;
    public GameObject[] Door;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.z <= 0 && isPlay)
        {
            gameManager.PuzzleNumber += 1;
            isPlay = false;
        }
        if (isRotate && isPlay) 
        {
            elapsedTime += Time.deltaTime;

            float progression = elapsedTime / mainTime;
            if (progression > 1.0f) progression = 1.0f;

            mainValue = Hermite(minValue, maxValue, progression);

            if (elapsedTime > mainTime) isRotate = false;

        }
        if (isPlay)
        {
            transform.rotation = Quaternion.Euler(0, 0, -mainValue);
        }
        if(gameManager.PuzzleNumber == 9)
        {
            StartCoroutine(WinPuzzle());
        }
    }


    public static float Hermite(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
    }

    public void OnMouseDown()
    {
        if (isPlay)
        {
            mainValue += 90;
            minValue += 90;
            maxValue += 90;
            elapsedTime = 0;
            isRotate = true;
            gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[10]);
        }
    }

    public IEnumerator WinPuzzle()
    {
        Door[0].SetActive(false);
        Door[1].SetActive(true);
        Door[2].SetActive(false);
        Door[3].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(Panel);
    }
}
