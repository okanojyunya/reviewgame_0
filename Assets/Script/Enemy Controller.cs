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
    float speedSave;
    Rigidbody rb;
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
        if (GameObject.Find("Player Body"))
        {
            isPlayer = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
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
