using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{

    private ItemHolder List;

    private void Awake()
    {
        List = GetComponentInChildren<ItemHolder>();
    }

    // Start is called before the first frame update
    public void AddItem()
    {
        var item = ItemPoolManager.Instance.GetEmptyItem();
        item.transform.SetParent(List.transform, false);
    }
}
