using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject PlayArea;
    public GameObject Canvas;
    
    private bool isDragging = false;
    private GameObject startParent;
    private Vector2 startPosition;
    private GameObject playArea;
    private bool isOverPlayArea;

    void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        PlayArea = GameObject.Find("PlayArea");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverPlayArea = true;
        playArea = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverPlayArea = false;
        playArea = null;
    }

    public void StartDrag()
    {
        isDragging = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverPlayArea){
            transform.SetParent(playArea.transform, false);
        } else {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

    void Update()
    {
        if (isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }
}
