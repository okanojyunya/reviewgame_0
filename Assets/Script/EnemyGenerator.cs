using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ԋu�œG�𐶐�����X�N���v�g
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    /// <summary>�G�̃v���n�u</summary>
    [SerializeField] GameObject enemy;
    /// <summary>�G�𐶐�����܂ł̃C���^�[�o��</summary>
    [SerializeField] float interval;
    /// <summary>�o�ߎ���</summary>
    float time;

    void Move()
    {
        time = Time.deltaTime;
        if (time > interval)
        {
            time = 0;
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }
    }
}
