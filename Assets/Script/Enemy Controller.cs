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
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (GameObject.Find("Player Body"))
        {
            isPlayer = true;
        }
    }
}
