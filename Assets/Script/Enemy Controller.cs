using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�𓮂����X�N���v�g
/// </summary>
public class EnemyController : MonoBehaviour
{
    /// <summary>�v���C���[�������������ǂ����̃t���O</summary>
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
