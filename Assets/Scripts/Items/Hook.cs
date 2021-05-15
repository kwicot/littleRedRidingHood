using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameObject PointStop;
    public bool isClick = false;

    void Update()
    {
        if (isClick)
        {
            transform.position = Vector2.MoveTowards(transform.position, PointStop.transform.position, 7 * Time.deltaTime);
        }
    }
}
