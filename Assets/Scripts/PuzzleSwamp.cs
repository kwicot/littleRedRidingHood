using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSwamp : MonoBehaviour
{
    public bool isRotate;

    public float mainTime = 5;      //время интерполяции
    public float elapsedTime;
    public float mainValue;
    public float minValue = 0;       //стартовая позиция
    public float maxValue = 0;  //конечная позиция
    public Stone Stone;
    public GameObject Panel;
    private GameManager gameManager;
    private bool isPlay = true;
    public bool isRight = true;


    void Start()
    {
        minValue = transform.localEulerAngles.z;
        maxValue = minValue + 90;
        mainValue = maxValue;
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.z <= 1 && isPlay)
        {
            Stone.RightStone += 1;
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
        if (isPlay && isRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, -mainValue);
        }
        else if (isPlay && isRight == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, mainValue);
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
            gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[11]);
        }
    }

}
