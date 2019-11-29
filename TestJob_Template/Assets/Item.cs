using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Item : MonoBehaviour
{
    private Text Text;
    private int _clickCount = 0;
    private SwipeArea SwipeArea;
    
    private int ClickCount
    {
        get { return _clickCount; }
        set
        {
            _clickCount = value;
            Text.text = "- " + gameObject.name + " - " + _clickCount + " clicks";
        }
    }
    
    private void Awake()
    {
        SwipeArea = GetComponentInChildren<SwipeArea>();
        Text = SwipeArea.GetComponentInChildren<Text>();
    }

    public void Clicked()
    {
        if(SwipeArea.LastMoveTime + 0.5f < Time.time)
            ClickCount++;
    }

    public void ReturnToPoll()
    {
        ClickCount = 0;
        SwipeArea.transform.localPosition = new Vector3(150, 0, 0);
        ItemPoolManager.Instance.RetunToPool(this);
    }
}
