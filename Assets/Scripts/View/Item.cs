using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image icon;
    public Action<Item, GameObject> onEndDrag;
    
    private Transform originalParent;

    void Start()
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;

        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject reachedObj = eventData.pointerCurrentRaycast.gameObject;
        if(reachedObj.transform == originalParent)
            return;

        onEndDrag?.Invoke(this, reachedObj);

        // if(reachedObj.tag == "Slot")
        // {
        //     originalParent = reachedObj.transform;
        // }
        // transform.SetParent(originalParent);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
