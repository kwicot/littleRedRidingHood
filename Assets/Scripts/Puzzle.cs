using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera MainCamera;
    private Vector3 offset;
    public Transform DefaulParent;
    public int id;
    public bool isBlock = false;
    void Awake()
    {
        MainCamera = Camera.allCameras[0];
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isBlock == false)
        {
            offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
            DefaulParent = transform.parent;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isBlock == false)
        {
            Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;
            offset.z = 0;
            transform.position = newPos + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isBlock == false)
        {
            transform.SetParent(DefaulParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
