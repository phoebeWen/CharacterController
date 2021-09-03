using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image icon;
    private bool isEmpty = true;
    public bool IsEmpty
    {
        set{
            isEmpty = value;
        }
        get{
            return isEmpty;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    // public void OnDrop(PointerEventData eventData)
    // {
    // }
}
