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
    
    public RawImage imgTarget;
    public RawImage imgTargetPress;

    public bool checkPosition = false;

    Vector2 positionstarter;

    private void Start()
    {
        positionstarter = transform.position;
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (Input.GetMouseButton(0))
        {
            UpdateMousePosition();
            CheckPosition();
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
        if (Vector3.Distance(imgTarget.transform.position,imgTargetPress.transform.position) < 5f)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            checkPosition = true;
        }
        else
        {
            checkPosition = false;
        }
    }

    public void CheckPositionLost()
    {
        if (checkPosition)
        {
            checkPosition = false;
        }
    }

    public void ResetBool()
    {
        checkPosition = false;
        gameObject.transform.position = positionstarter;
    }

}
