using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    public GameObject PointStop;
    public bool isFeedClick = false;

    void Update()
    {
        if (isFeedClick)
        {
            transform.position = Vector2.MoveTowards(transform.position, PointStop.transform.position, 7 * Time.deltaTime);
        }
    }
}
