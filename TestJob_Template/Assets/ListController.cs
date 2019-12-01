using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListController : MonoBehaviour
{
    public static ScrollRect ScrollRect;
    private ItemHolder List;

    private void Awake()
    {
        List = GetComponentInChildren<ItemHolder>();
        ScrollRect = GetComponentInChildren<ScrollRect>();
    }

    // Start is called before the first frame update
    public void AddItem()
    {
        var item = ItemPoolManager.Instance.GetEmptyItem();
        item.transform.SetParent(List.transform, false);
    }
}
