using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーに関するスクリプト
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController charaCon;
    Vector3 dir;
    Rigidbody rb;
    [SerializeField] float moveSpeed = 1.0f;//プレイヤーのスピード
    [SerializeField] float turnSpeed = 1.0f;//回転速度
    /// <summary>時を止めるためのフラグtrueの時は時を動かす</summary>
    bool stopTime = false;
    /// <summary>ジャンプできるかどうかのフラグ</summary>
    bool isJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;
        dir = transform.right * x + transform.forward * z;
        charaCon.Move(dir * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        transform.Rotate(Vector3.up * mouseX);
    }
}
