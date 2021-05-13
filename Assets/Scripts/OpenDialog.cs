using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialog : MonoBehaviour
{
    public GameObject Dialog;
    public string KeyName;
    void Start()
    {
        var number = PlayerPrefs.GetInt(KeyName);
        if (number == 0)
        {
            StartCoroutine(DelayOpenDialog());
        }
    }
    IEnumerator DelayOpenDialog()
    {
        yield return new WaitForSeconds(1.5f);
        Dialog.SetActive(true);
        PlayerPrefs.SetInt(KeyName, 1);
        Destroy(gameObject);
    }
}
