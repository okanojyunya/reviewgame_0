using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一定間隔で敵を生成するスクリプト
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    /// <summary>敵のプレハブ</summary>
    [SerializeField] GameObject enemy;
    /// <summary>敵を生成するまでのインターバル</summary>
    [SerializeField] float interval;
    /// <summary>経過時間</summary>
    float time;

    public void Move()
    {
        time = Time.deltaTime;
        if (time > interval)
        {
            time = 0;
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }
    }
}
