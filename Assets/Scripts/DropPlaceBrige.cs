using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlaceBrige : MonoBehaviour, IDropHandler
{
    public bool isFull = false;
    public Bridge bridge;
    private GameObject Book;
    public int id;


    public void OnDrop(PointerEventData eventData)
    {
        Puzzle puzzle = eventData.pointerDrag.GetComponent<Puzzle>();
        if (puzzle)
        {
            if (puzzle.id == id)
            {
                puzzle.DefaulParent = transform;
                isFull = true;
                Book = puzzle.gameObject;
                Debug.Log(puzzle.id);
                StartCoroutine(TimeBlock());
            }
            IEnumerator TimeBlock()
            {
                yield return new WaitForSeconds(0.1f);
                puzzle.isBlock = true;
                bridge.RightBridge += 1;
            }
        }
    }
}
