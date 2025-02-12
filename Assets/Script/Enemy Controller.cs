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
    /// <summary>リスポンする場所</summary>
    [SerializeField] GameObject reponPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(0, 0, speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        //プレイヤーに当たったらフラグをtrueにする
        if (GameObject.Find("Player Body"))
        {
            isPlayer = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Wallに当たったら最初の位置に移動する
        if (GameObject.Find("Wall"))
        {
            this.gameObject.transform.position = reponPos.transform.position;
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
