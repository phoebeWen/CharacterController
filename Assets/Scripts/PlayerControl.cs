using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Tooltip("移动速度")]
    public float movespeed = 3f;
    [Tooltip("冲刺速度")]
    public float mprintspeed = 5f;
    [Tooltip("跳跃高度")]
    public float jumpPower = 2.2f;
    [Tooltip("重力")]
    public float gravity = 7f;
    [Tooltip("鼠标速度")]
    public float mousespeed = 3f;
    [Tooltip("最高落下不扣血")]
    public float maxFallNoDamage = 3f;
    [Tooltip("限制最小角度")]
    public float minmouseY = -60f;
    [Tooltip("限制最大角度")]
    public float maxmouseY = 65f;

    GameObject resurrectionPoint;
    CharacterController playerController;

    float recordMovespeed;
    float recordgravity;
    float rotationY = 0f;
    float rotationX = 0f;
    float recordHeight;

    Transform agretctCamera;
    
    void Start()
    {
        recordMovespeed = movespeed;
        recordgravity = gravity;

        playerController = GetComponent<CharacterController>();
        agretctCamera = GameObject.FindWithTag("PlayerCamera").transform;
        resurrectionPoint = GameObject.Find("ResurrectionPoint");
    }

    void FixedUpdate()
    {
        if(Input.touchCount == 1)
        {
            Debug.Log("xxxxx");
        }
    }
}
