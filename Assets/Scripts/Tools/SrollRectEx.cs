using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SrollRectEx : ScrollRect //, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private int count;
    private float[] stepPoints;
    private bool lerp = false;
    private int startIndex = 0;
    private float targetPosition = 0f;

    protected override void Start()
    {
        // scrollRect = GetComponent<ScrollRect>();
        count = this.content.childCount;
        stepPoints = new float[count];
        this.horizontalNormalizedPosition = 0f;

        float stepSize = 1 / (float)(count - 1);
        for (int index = 0; index < count; index++)
        {
            stepPoints[index] = stepSize * index;
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        lerp = false;
        if (TryGetSibilingIndex(this.horizontalNormalizedPosition, out startIndex))
        {
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        int targetPointIndex = 0;
        if (TryGetSibilingIndex(this.horizontalNormalizedPosition, out targetPointIndex))
        {
            lerp = true;
            targetPosition = stepPoints[targetPointIndex];
        }
    }

    void Update()
    {
        if (lerp)
        {
            this.horizontalNormalizedPosition = Mathf.Lerp(this.horizontalNormalizedPosition, 
                targetPosition, 0.3f);
            
            lerp = Mathf.Abs(this.horizontalNormalizedPosition - targetPosition) > 0.001f;
        }
    }

    private bool TryGetSibilingIndex(float val, out int sIndex)
    {
        sIndex = 0;
        if (null == stepPoints || stepPoints.Length <= 0)
        {
            return false;
        }

        float distance = Mathf.Infinity;
        for (int index = 0; index < stepPoints.Length; index++)
        {
            if(Mathf.Abs(stepPoints[index] - val) < distance)
            {
                distance = Mathf.Abs(val - stepPoints[index]);
                sIndex = index;
            }
        }
        return true;
    }
}
