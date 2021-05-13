using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScr : MonoBehaviour
{

    public bool isRotate;
    public bool clickTree = false;
    public float mainTime = 5;      //время интерполяции
    public float elapsedTime;
    public float mainValue;
    public float minValue = 0;       //стартовая позиция
    public float maxValue = 0;  //конечная позиция
    public GameObject Wolf;
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clickTree)
        {


            elapsedTime += Time.deltaTime;

            float progression = elapsedTime / mainTime;
            if (progression > 1.0f) progression = 1.0f;

            mainValue = Hermite(minValue, maxValue, progression);

            if (elapsedTime > mainTime)
            {
                isRotate = false;
                Destroy(Wolf);
            }


            transform.rotation = Quaternion.Euler(0, 0, -mainValue);
        }
    }


    public static float Hermite(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
    }
    public void ClickTree()
    {
        gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[24]);
        clickTree = true;
    }
}
