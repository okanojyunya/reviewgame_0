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
        // 衝突相手のタグを確認
        if (collision.gameObject.CompareTag("Player") && isGameOver == false)
        {
            // プレイヤーと接触した場合
            isGameClear = true;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // 地面と接触した場合
            isGameOver = true;
        }
    }
}
