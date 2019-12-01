﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeArea : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public float dragSpeed = 1f;
    public float minY = 100;
    public float maxY = 150;
    Vector3 lastMousePos;

    private Vector3 beforeMove;

    private bool inMove = false;
    public float LastMoveTime = 0;
    
    private void Awake()
    {
        beforeMove = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ListController.ScrollRect.verticalNormalizedPosition -= eventData.delta.y / ((float)Screen.height);
        if (!inMove)
        {
            return;
        }
        Vector3 delta = Input.mousePosition - lastMousePos;
        Vector3 pos = transform.localPosition;
        pos.x += delta.x * dragSpeed;
        pos.x = Mathf.Clamp(pos.x, minY, maxY);
        transform.localPosition = pos;
        lastMousePos = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        LastMoveTime = Time.time;
        inMove = true;
        beforeMove = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        LastMoveTime = Time.time;
        var x = Vector3.Distance(beforeMove, transform.position);
        if (x >= 20)
        {
            if (Math.Abs(beforeMove.x) > 410)
            {
                transform.localPosition = new Vector3(100, 0, 0);
            }
            else if (Math.Abs(beforeMove.x) >= 350)
            {
                transform.localPosition = new Vector3(150, 0, 0);
            }
        }
        else transform.position = new Vector3(beforeMove.x, 0, beforeMove.z);

        inMove = false;
    }
}
