using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraControl : MonoBehaviour
{
    //�J�������x
    [SerializeField] float xSens = 1f;
    [SerializeField] float ySens = 1f;

    private void Start()
    {
        //�J�[�\���𒆐S�ɌŒ�
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        CameraRotate_Mouse();
    }

    private void CameraRotate_Mouse()
    {
        //�}�E�X�̈ړ��ʎ擾
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //Y�����S�ɃJ��������]
        transform.RotateAround(transform.position, Vector3.up, x * xSens);
        //�J������X���𒆐S�ɉ�]
        transform.RotateAround(transform.position, transform.right, -y * ySens);
    }
}
