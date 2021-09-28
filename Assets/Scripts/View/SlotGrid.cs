using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotGrid : MonoBehaviour
{
    public List<GameObject> slotList;

    [HideInInspector]
    public List<Item> itemList;

    public void SetContent(SrollRectEx scrollView)
    {
        itemList = new List<Item>();

        for (int index = 0; index < slotList.Count; index++)
        {
            GameObject obj = slotList[index];
            if(obj.transform.childCount > 0)
            {
                Item item = obj.GetComponentInChildren<Item>();
                item.SetContent(scrollView);
                
                itemList.Add(item);
            }
        }
    }
}
