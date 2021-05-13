using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject PaperHeating;
    public GameObject Paper;

    public void heating()
    {
        PaperHeating.SetActive(true);
        StartCoroutine(DestroyPaper());
    }

    IEnumerator DestroyPaper()
    {
        yield return new WaitForSeconds(1);
        Destroy(PaperHeating);
        Destroy(Paper);
    }
}
