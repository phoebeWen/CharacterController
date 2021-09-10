using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
    public List<GameObject> slotList;

    [HideInInspector]
    public List<Item> itemList;

    void Start()
    {
        itemList = new List<Item>();

        UpdateSlot();
    }

    public void UpdateSlot()
    {
        for (int index = 0; index < slotList.Count; index++)
        {
            GameObject obj = slotList[index];
            if(obj.transform.childCount > 0)
            {
                Item item = obj.GetComponentInChildren<Item>();
                itemList.Add(item);
            }
        }
    }
}
