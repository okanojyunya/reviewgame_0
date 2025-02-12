using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�C�e���Ɋւ���X�N���v�g
/// </summary>
public class ItemController : MonoBehaviour
{
    /// <summary>�Q�[���N���A�t���O</summary>
    public bool isGameClear = false;
    /// <summary>�Q�[���I�[�o�[�t���O</summary>
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
        // �Փˑ���̃^�O���m�F
        if (collision.gameObject.CompareTag("Player") && isGameOver == false)
        {
            // �v���C���[�ƐڐG�����ꍇ
            isGameClear = true;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // �n�ʂƐڐG�����ꍇ
            isGameOver = true;
        }
    }
}
