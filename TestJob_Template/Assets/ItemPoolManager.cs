using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoolManager : MonoBehaviour
{
    private static ItemPoolManager _instance;
    private static object m_Lock = new object();

    private Item ItemTemplate;
    
    public static ItemPoolManager Instance
    {
        get
        {
            lock (m_Lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ItemPoolManager>();

                    if (_instance == null)
                    {
                        GameObject deckPoolProxy = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        deckPoolProxy.AddComponent<ItemPoolManager>();
                        _instance = deckPoolProxy.GetComponent<ItemPoolManager>();    
                        _instance.Awake();
                    }
                }
            }

            return _instance;
        }
        set { _instance = value; }
    }
    
        private List<Item> _itemsPool;

        private Transform _transform;
        

        private void Awake()
        {
            _itemsPool = new List<Item>();
            ItemTemplate = GetComponentInChildren<Item>();
        }
        
        public Item GetEmptyItem()
        {
            Item newItem = GetUnitHolderFromPool();
            if (newItem == null) newItem = Instantiate(Instance.ItemTemplate);
            return newItem;
        }
    
        
        private Item GetUnitHolderFromPool()
        {
            if(_itemsPool == null) _itemsPool = new List<Item>();
            Item temp = Instance._itemsPool.Find(x=> x);
            if (temp != null)
            {
                Instance._itemsPool.Remove(temp);
            }
            return temp;
        }

        public void RetunToPool(Item item)
        {
            item.transform.SetParent(Instance._transform);
            item.transform.localPosition = Vector3.zero;
            Instance._itemsPool.Add(item);
        }


}
