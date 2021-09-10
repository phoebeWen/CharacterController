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
    private Vector3 originalPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        float angle = Vector2.Angle(Vector2.right, eventData.delta);
        if(angle < 30 || angle > 150)
        { 
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            return;
        }

        originalParent = transform.parent;
        originalPos = transform.position;

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
        if (reachedObj.tag == "Slot")
        {
            originalParent = reachedObj.transform;
            transform.SetParent(originalParent);
        }
        else if (reachedObj.gameObject.name == "img")
        {
            Transform newParent = reachedObj.transform.parent.parent;
            Vector3 newPos = reachedObj.transform.parent.position;

            transform.SetParent(newParent);
            transform.position = newPos;

            reachedObj.transform.parent.SetParent(originalParent);
            reachedObj.transform.parent.position = originalPos;

            originalParent = newParent;
        }
        else
        {
            transform.SetParent(originalParent);
            transform.position = originalPos;
        }

        RectTransform rect = transform.GetComponent<RectTransform>();
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;

        originalPos = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
