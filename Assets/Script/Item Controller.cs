using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムに関するスクリプト
/// </summary>
public class ItemController : MonoBehaviour
{
    /// <summary>ゲームクリアフラグ</summary>
    public bool isGameClear = false;
    /// <summary>ゲームオーバーフラグ</summary>
    public bool isGameOver = false;
    Rigidbody rb;
    Vector3 velocity;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        rb.WakeUp();
        velocity = rb.velocity;
    }

    public void Stop()
    {
        velocity = rb.velocity;
        rb.Sleep();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //ゲームクリア条件地面に地面に触れる前にプレイヤーに当たること
        if (GameObject.Find("Player Body") && isGameOver == false)
        {
            isGameClear = true;
        }
        //ゲームオーバー条件地面に触れたら
        if (GameObject.FindWithTag("Ground"))
        {
            isGameOver = true;
        }
    }
}
