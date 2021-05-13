using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBook : MonoBehaviour
{
    public GameObject PointStop;
    private int i = 0;
    public bool GreanBookActive = false;
    public bool isActivBook = false;
    public bool isActivBook1 = false;
    public bool isActivBook2 = false;
    public bool isActivBook3 = false;
    public bool isActivBook4 = false;
    public bool isActivBook5 = false;


    void Update()
    {
        if(GreanBookActive == true && isActivBook == true && isActivBook1 == true && isActivBook2 == true && isActivBook3 == true && isActivBook4 == true && isActivBook5 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, PointStop.transform.position, 10 * Time.deltaTime);
            if (i == 0)
            {
                StartCoroutine(DestroyTime());
                i++;
            }

        }

    }
    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

