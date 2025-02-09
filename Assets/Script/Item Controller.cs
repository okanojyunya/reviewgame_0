using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�C�e���Ɋւ���X�N���v�g
/// </summary>
public class ItemController : MonoBehaviour
{
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
}
