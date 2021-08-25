using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    CharacterController controller;
    public float velocity = 0f;
    float gravity = -9.8f;
    Vector3 direction;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(controller.isGrounded)
        {
            direction = new Vector3(horizontal, 0, vertical);
        }
        direction.y += gravity * Time.deltaTime;

        controller.Move(controller.transform.TransformDirection(direction * Time.deltaTime * velocity));//每帧的变化量
    }
}

/*public class PlayerControl : MonoBehaviour
{
    CharacterController playerController;
    Vector3 direction;

    [Tooltip("移动速度")]
    public float Movespeed = 3f;
    [Tooltip("冲刺速度")]
    public float Sprintspeed = 5f;
    [Tooltip("跳跃高度")]
    public float jumpPower = 2.2f;
    [Tooltip("重力")]
    public float gravity = 7f;
    [Tooltip("鼠标速度")]
    public float mousespeed = 3f;
    [Tooltip("最高落下不扣血")]
    public float MaxFallNoDamage = 3f;
    [Tooltip("限制最小角度")]
    public float minmouseY = -60f;
    [Tooltip("限制最大角度")]
    public float maxmouseY = 65f;
    GameObject PlayResurrectionPoints;
    float RecordMovespeed;
    float Recordgravity;
    float RotationY = 0f;
    float RotationX = 0f;
    float RecordHeight;
    Transform agretctCamera;

    Vector2 m_screenpos = new Vector2();
    // Use this for initialization
    void Start()
    {
        // Debug.Log(gameObject.transform.forward);

        RecordMovespeed = Movespeed;
        Recordgravity = gravity;
        playerController = GetComponent<CharacterController>();
        agretctCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Transform>();
        PlayResurrectionPoints = GameObject.Find("ResurrectionPoint");
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        
        if(Input.touchCount == 1)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                m_screenpos = Input.touches[0].position;
            }
        }
        // Debug.Log(m_screenpos);

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        if (playerController.isGrounded)
        {
            direction = new Vector3(_horizontal, 0, _vertical);
            if (Input.GetKeyDown(KeyCode.Space))
                direction.y = jumpPower;
            if(RecordHeight - transform.localPosition.y  > MaxFallNoDamage)
            {
                //这里可以写摔伤的函数
                //这个是得出超出高度的值
                Debug.Log((RecordHeight - transform.localPosition.y) - MaxFallNoDamage);
            }
            RecordHeight = 0;
        }
        direction.y -= gravity * Time.deltaTime;
        playerController.Move(playerController.transform.TransformDirection(direction * Time.deltaTime * Movespeed));

        // RotationX += agretctCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousespeed;
        // RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        // RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);
        // this.transform.eulerAngles = new Vector3(0, RotationX, 0);

        // agretctCamera.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);
        // Debug.Log(Time.deltaTime);

        RotationX += Input.GetAxis("Mouse X") * mousespeed;
        RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);

        transform.rotation = Quaternion.Euler(0, RotationX, 0);
        agretctCamera.transform.rotation = Quaternion.Euler(RotationY, RotationX, 0);


        //冲刺
        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.RightShift))
        {
            if (Movespeed != Sprintspeed)
            {
                Movespeed = Sprintspeed;
                gravity = 12f;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.W))
        {
            if (Movespeed != Sprintspeed)
            {
                Movespeed = Sprintspeed;
                gravity = 12f;
            }
        }
        if (Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.RightShift))
        {
            Movespeed = RecordMovespeed;
            gravity = Recordgravity;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            Movespeed = RecordMovespeed;
            gravity = Recordgravity;
        }
        //如果玩家掉入深渊回到复活点
        if (gameObject.transform.localPosition.y < -50)
        {
            gameObject.transform.position = new Vector3(PlayResurrectionPoints.transform.position.x, PlayResurrectionPoints.transform.position.y, PlayResurrectionPoints.transform.position.z);
        }

        //记录高度，玩家是否摔伤
        if(transform.localPosition.y > RecordHeight)
        {
            RecordHeight = transform.localPosition.y;
        }
    }
}*/