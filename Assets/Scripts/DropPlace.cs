using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public bool isFull = false;
    private RedBook redBook;
    private GameObject Book;
    public int id;

    void Start()
    {
        redBook = GameObject.FindGameObjectWithTag("Book").GetComponent<RedBook>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Puzzle puzzle = eventData.pointerDrag.GetComponent<Puzzle>();
        if(puzzle)
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
                if(id == 1)
                {
                    redBook.isActivBook = true;
                }
                else if (id == 2)
                {
                    redBook.isActivBook1 = true;
                }
                else if (id == 3)
                {
                    redBook.isActivBook2 = true;
                }
                else if (id == 4)
                {
                    redBook.isActivBook3 = true;
                }
                else if (id == 5)
                {
                    redBook.isActivBook4 = true;
                }
                else if (id == 6)
                {
                    redBook.isActivBook5 = true;
                }
            }
        }
    }
}
