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
    [Tooltip("�v���C���[���~�܂������ɂ��鏈��")]
    [SerializeField] UnityEvent onStop;
    [Tooltip("�Q�[���I�[�o�[�����Ƃ��ɂ��鏈��")]
    [SerializeField] UnityEvent onGameOver;
    [Tooltip("�Q�[���N���A�����Ƃ��ɂ��鏈��")]
    [SerializeField] UnityEvent onGameClear;

    GameObject player;
    GameObject enemy;
    GameObject item;
    /// <summary>�v���C���[�ɂ��Ă���X�N���v�g</summary>
    PlayerController playerController;
    /// <summary>�G�ɂ��Ă���X�N���v�g</summary>
    EnemyController enemyController;
    /// <summary>�A�C�e���ɂ��Ă���X�N���v�g</summary>
    ItemController itemController;
    private void Start()
    {
        player = GameObject.Find("Player Body");
        enemy = GameObject.FindWithTag("Enemy");
        item = GameObject.FindWithTag("Item");
        playerController = player.GetComponent<PlayerController>();
        enemyController = enemy.GetComponent<EnemyController>();
        itemController = item.GetComponent<ItemController>();
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
        //�Q�[���I�[�o�[���� > item���n�ʂɗ������Ƃ��ƃv���C���[�����񂾂Ƃ�
        //playerController�Ńv���C���[�̏�Ԃ��t���O�ŊǗ�����
        if (enemyController.isPlayer == true || itemController.isGameOver == true)
        {
            GameOver();
        }
        //�Q�[���N���A���� > item���n�ʂɗ�����O�Ƀv���C���[���G���
        if (itemController.isGameClear == true)
        {
            onGameClear.Invoke();
        }

    }
    /// <summary>
    /// �Q�[���I�[�o�[�̏���������������s���鏈��
    /// </summary>
    public void GameOver()
    {
        onGameOver.Invoke();
        Debug.Log("aa");
    }
}
