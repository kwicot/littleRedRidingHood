using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [HideInInspector]public SOItem MainData;
    private Inventory inventory;
    private Button button;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();
    }

    private void Awake()
    {
      
    }

    public void OnClick()
    {
        if(inventory.CraftMode)
            inventory.TryCraft(this);
        else inventory.Equipt(this);
    }

    public void SetSlot(Slot slot)
    {
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => OnClick());
        slot.selectedItemController = this;
       
        var trans = slot.gameObject.transform;
        transform.SetParent(trans);
        transform.position = trans.position;
        transform.localScale = new Vector3(1,1,1);
    }
}
