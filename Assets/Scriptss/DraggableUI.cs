using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IDragHandler
{
    private Vector2 mousePosition = new Vector2();
    private Vector2 startPosition = new Vector2();
    private Vector2 differencePoint = new Vector2();

    private Transform _point1;
    private Transform _point2;
    
    public RawImage img;
    public RawImage img2;

    public bool checkPosition = false;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateMousePosition();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            UpdateStartPosition();
            UpdateDifferencePoint();
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = mousePosition - differencePoint;
    }

    private void UpdateMousePosition()
    {
        mousePosition.x = Input.mousePosition.x;
        mousePosition.y = Input.mousePosition.y;
    }

    private void UpdateStartPosition()
    {
        startPosition.x = transform.position.x;
        startPosition.y = transform.position.y;
    }

    private void UpdateDifferencePoint()
    {
        differencePoint = mousePosition - startPosition;
    }

    public void CheckPosition()
    {
        if (!checkPosition)
        {
            checkPosition = true;
        }
    }

    public void CheckPositionLost()
    {
        if (checkPosition)
        {
            checkPosition = false;
        }
    }
}