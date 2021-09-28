using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryView : MonoBehaviour
{
    public List<SlotGrid> slotGrid;
    public SrollRectEx scrollView;
    void Start()
    {
        // 测试代码
        for(int index = 0;index < slotGrid.Count; index++)
        {
            slotGrid[index].SetContent(scrollView);
        }
    }
}
