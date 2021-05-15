using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public int RightBridge = 0;
    public GameObject Bridge2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RightBridge == 5)
        {
            Bridge2.SetActive(true);
            Destroy(gameObject);
        }
    }
}
