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
    /// <summary>�X�s�[�h</summary>
    [SerializeField] float speed = 0f;
    Rigidbody rb;
    /// <summary>���X�|������ꏊ</summary>
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
        //�v���C���[�ɓ���������t���O��true�ɂ���
        if (GameObject.Find("Player Body"))
        {
            isPlayer = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Wall�ɓ���������ŏ��̈ʒu�Ɉړ�����
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
