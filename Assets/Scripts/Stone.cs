using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject PointStop;
    public bool isAllRightBook = false;
    private int i = 0;
    public int RightStone;

    void Update()
    {
        if (RightStone == 5)
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
