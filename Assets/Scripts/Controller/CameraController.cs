using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
    public float moveSpeed;

    public float scrollSpeed;
    public float maxZoomIn;
    public float maxZoomOut;

    float curZoom;
    Vector3 curVelocity;
    Vector3 curOffset;
    Vector3 updateOffset;
    Transform targetTransform;

    void Start()
    {
        curOffset = offset;
        updateOffset = offset;

        GameObject camTarget = new GameObject("CameraTarget");
        targetTransform = camTarget.transform;
        targetTransform.position = transform.position;
        targetTransform.rotation = transform.rotation;
    }

    // 等到人物移动完成后移动摄像机 不然会有抖动的现象
    void LateUpdate()
    {
        FollowPlayer();
        ScrollView();
    }

    void FollowPlayer()
    {
        transform.position = followTarget.position + curOffset;
    }

    void ScrollView()
    {
        // Debug.Log(Input.mouseScrollDelta.y);
        curZoom += Input.mouseScrollDelta.y * scrollSpeed;
        curZoom = Mathf.Clamp(curZoom, -maxZoomOut, maxZoomIn);

        // Debug.Log(curZoom);
        curOffset = updateOffset - updateOffset * curZoom;

        Vector3 newPos = followTarget.position + curOffset;
        targetTransform.position = newPos;

        // transform.position = targetTransform.position; 
        transform.position = Vector3.SmoothDamp(transform.position, targetTransform.position, ref curVelocity, 1f / moveSpeed);
    }
}
