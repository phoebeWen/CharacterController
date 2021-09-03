using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
    List<Slot> slotList;
    void Start()
    {
        slotList = new List<Slot>();
        for(int index = 0; index < transform.childCount; index++)
        {
            Slot s = transform.GetChild(index).GetComponent<Slot>();
            slotList.Add(s);
        }
    }
}
