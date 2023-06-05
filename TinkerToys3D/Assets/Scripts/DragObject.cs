using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public Camera myCam;
    
    private float startXPos;
    private float startYPos;

    private bool isDragging = false;

    private void Update()
    {
        if (isDragging)
        {
            Drag();
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        
        if (!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void Drag()
    {
        Vector3 mousePos = Input.mousePosition;

        if(!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);
        transform.localPosition = new Vector3(mousePos.x - startXPos, mousePos.y - startYPos, transform.localPosition.z);
    }
    
}
