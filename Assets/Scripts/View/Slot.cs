using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
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

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop item");
    }
}
