using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵を動かすスクリプト
/// </summary>
public class EnemyController : MonoBehaviour
{
    /// <summary>プレイヤーが当たったかどうかのフラグ</summary>
    public bool isPlayer = false;
    /// <summary>スピード</summary>
    [SerializeField] float speed = 0f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(speed, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        //プレイヤーに当たったらフラグをtrueにする
        if (GameObject.FindWithTag("Player"))
        {
            isPlayer = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Wallに当たったら最初の位置に移動する
        if (GameObject.Find("Wall"))
        {
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        rb.WakeUp();
    }
    public void Stop()
    {
        rb.Sleep();
    }
}
