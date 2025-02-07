using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�Ɋւ���X�N���v�g
/// </summary>
public class PlayerController : MonoBehaviour
{
    Vector3 dir;
    Rigidbody rb;
    [SerializeField] float moveSpeed = 1.0f;//�v���C���[�̃X�s�[�h
    [SerializeField] float turnSpeed = 1.0f;//��]���x
    [SerializeField] float jumpPower = 1.0f;//�W�����v��
    /// <summary>�����~�߂邽�߂̃t���Otrue�̎��͎��𓮂���</summary>
    bool stopTime = false;
    /// <summary>�ڒn�t���O</summary>
    bool isJumped = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    ///�v���C���[�̈ړ����� 
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
        //���ꂼ��̃L�[���͒l����
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        dir = new Vector3(moveH, 0, moveV);
        dir *= moveSpeed;
        ////�W�����v����
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
