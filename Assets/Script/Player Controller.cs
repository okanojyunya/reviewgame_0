using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�Ɋւ���X�N���v�g
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController charaCon;
    Vector3 dir;
    Rigidbody rb;
    [SerializeField] float moveSpeed = 1.0f;//�v���C���[�̃X�s�[�h
    [SerializeField] float turnSpeed = 1.0f;//��]���x
    /// <summary>�����~�߂邽�߂̃t���Otrue�̎��͎��𓮂���</summary>
    bool stopTime = false;
    /// <summary>�W�����v�ł��邩�ǂ����̃t���O</summary>
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
