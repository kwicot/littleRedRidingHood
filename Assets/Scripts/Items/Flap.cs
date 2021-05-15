using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flap : MonoBehaviour
{
    public GameObject PointStop;
    private GameManager gameManager;
    public bool isClick = false;
    private int i = 0;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }
    void Update()
    {
        if (isClick)
        {
            transform.position = Vector2.MoveTowards(transform.position, PointStop.transform.position, 15 * Time.deltaTime);
            
        }
        if(isClick && i == 0)
        {
            gameManager.Sounds.PlayOneShot(gameManager.SoundsGame[28]);
            i = 1;
        }
    }
}
