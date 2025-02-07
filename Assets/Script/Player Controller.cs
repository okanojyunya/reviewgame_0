using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーに関するスクリプト
/// </summary>
public class PlayerController : MonoBehaviour
{
    Vector3 dir;
    Rigidbody rb;
    [SerializeField] float moveSpeed = 1.0f;//プレイヤーのスピード
    [SerializeField] float turnSpeed = 1.0f;//回転速度
    [SerializeField] float jumpPower = 1.0f;//ジャンプ力
    /// <summary>時を止めるためのフラグtrueの時は時を動かす</summary>
    bool stopTime = false;
    /// <summary>接地フラグ</summary>
    bool isJumped = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    ///プレイヤーの移動処理 
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        Vector3 desireMove = cameraForward * dir.z + cameraRight * dir.x;

        rb.velocity = desireMove + new Vector3(0, rb.velocity.y, 0);
    }

    void Update()
    {
        //それぞれのキー入力値を代入
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        dir = new Vector3(moveH, 0, moveV);
        dir *= moveSpeed;
        ////ジャンプ処理
        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (isJumped)
        //    {
        //        Jump();
        //    }
        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    isJumped = true;
    //}

    //void Jump()
    //{
    //    Vector3 velocity = rb.velocity;
    //    velocity.y = jumpPower;
    //    rb.velocity = velocity;
    //}
}
