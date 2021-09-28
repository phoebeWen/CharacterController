using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Item : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{  
    public Image icon;
    public Action<Item, GameObject> onEndDrag;

    private Transform originalParent;
    private Vector3 originalPos;
    private SrollRectEx scrollView;
    private bool swap = false;

    public void SetContent(SrollRectEx sr)
    {
        scrollView = sr;

        originalParent = transform.parent;
        originalPos = transform.position;
    }

    public void OnBeginDrag(BaseEventData bEvent)
    {
        PointerEventData eventData = bEvent as PointerEventData;
        float angle = Vector2.Angle(Vector2.right, eventData.delta);

        if(swap = angle > 30f && angle < 150f)
        {
            scrollView.StopMovement();
            transform.GetComponent<CanvasGroup>().blocksRaycasts = false;

            originalParent = transform.parent;
            originalPos = transform.position;

            transform.SetParent(transform.parent.parent);
            transform.position = eventData.position;
        }
        else
        {
            scrollView.OnBeginDrag(eventData);
        }
    }

    public void OnDrag(BaseEventData bEvent)
    {
        PointerEventData eventData = bEvent as PointerEventData;
        if(swap)
        {
            transform.position = eventData.position;
        }
        else
        {
            scrollView.OnDrag(eventData);
        }
    }

    public void OnEndDrag(BaseEventData bEvent)
    {
        PointerEventData eventData = bEvent as PointerEventData;
        GameObject reachedObj = eventData.pointerCurrentRaycast.gameObject;
        if(null == reachedObj)
        {
            transform.SetParent(originalParent);
            transform.position = originalPos;

            scrollView.OnEndDrag(eventData);
        }
        else if(swap)
        {
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
        }
        else
        {
            scrollView.OnEndDrag(eventData);
        }

        RectTransform rect = transform.GetComponent<RectTransform>();
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;

        originalPos = transform.position;
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
