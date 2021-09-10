using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryView : MonoBehaviour, IBeginDragHandler
{
    public List<SlotGrid> slotGrid;
    public ScrollRect scrollView;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // float angle = Vector2.Angle(Vector2.right, eventData.delta);
        // if(angle > 30 && angle < 150 && eventData.pointerCurrentRaycast.gameObject.name == "img")
        // {
        //     scrollView.StopMovement();
        //     return;
        // }
    }

    void Start()
    {
        // 测试代码
        // UpdateInventory();
    }
    
    void Update()
    {
        
    }

    private void UpdateInventory()
    {

    }
}
