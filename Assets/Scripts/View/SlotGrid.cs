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
    }

    public void UpdateSlot()
    {
        for (int index = 0; index < slotList.Count; index++)
        {
            GameObject obj = slotList[index];
            if(obj.transform.childCount > 0)
            {
                Item item = obj.GetComponentInChildren<Item>();
                item.onEndDrag +=  EndDrag;

                itemList.Add(item);
            }
        }
    }

    public void EndDrag(Item item, GameObject obj)
    {
        
    }
}
