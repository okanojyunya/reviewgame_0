using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �Q�[�����Ǘ�����B�K���ȃI�u�W�F�N�g�ɃA�^�b�`���Ċe��ݒ������Γ���\
/// </summary>
public class GameManegarController : MonoBehaviour
{
    [Tooltip("�v���C���[���������Ƃ��ɂ��鏈��")]
    [SerializeField] UnityEvent onMoved;

    [SerializeField] UnityEvent onStop;
    GameObject player;
    /// <summary>�v���C���[�ɂ��Ă���X�N���v�g</summary>
    PlayerController playerController;

    private void Start()
    {
        player = GameObject.Find("Player Body");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.isMoved == true)
        {
            onMoved.Invoke();
        }
        if (playerController.isMoved == false)
        {
            onStop.Invoke();
        }
    }

}
