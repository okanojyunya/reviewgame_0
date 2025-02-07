using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraControl : MonoBehaviour
{
    //カメラ感度
    [SerializeField] float xSens = 1f;
    [SerializeField] float ySens = 1f;

    private void Start()
    {
        //カーソルを中心に固定
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        CameraRotate_Mouse();
    }

    private void CameraRotate_Mouse()
    {
        //マウスの移動量取得
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //Y軸中心にカメラを回転
        transform.RotateAround(transform.position, Vector3.up, x * xSens);
        //カメラのX軸を中心に回転
        transform.RotateAround(transform.position, transform.right, -y * ySens);
    }
}
