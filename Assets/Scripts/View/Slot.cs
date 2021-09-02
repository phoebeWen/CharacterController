using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Image itemImg;
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
}
