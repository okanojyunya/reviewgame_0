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
    GameObject item;

    /// <summary>�v���C���[�ɂ��Ă���X�N���v�g</summary>
    PlayerController playerController;
    /// <summary>�A�C�e���ɂ��Ă���X�N���v�g</summary>
    ItemController itemController;

    /// <summary>���ׂĂ̓G�I�u�W�F�N�g</summary>
    List<EnemyController> enemyControllers = new List<EnemyController>();

    private void Start()
    {
        // �v���C���[�ƃA�C�e�����擾
        player = GameObject.Find("Player Body");
        item = GameObject.FindWithTag("Item");

        playerController = player.GetComponent<PlayerController>();
        itemController = item.GetComponent<ItemController>();

        // ���ׂĂ̓G�I�u�W�F�N�g���擾���AEnemyController�����X�g�ɒǉ�
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            EnemyController controller = enemy.GetComponent<EnemyController>();
            if (controller != null)
            {
                enemyControllers.Add(controller);
            }
        }
    }

    private void Update()
    {
        // �v���C���[�����������ǂ����̃`�F�b�N
        if (playerController.isMoved)
        {
            onMoved.Invoke();
        }
        else
        {
            onStop.Invoke();
        }

        // �Q�[���I�[�o�[����: �����ꂩ�̓G��isPlayer == true �܂��� item���n�ʂɗ������ꍇ
        bool isGameOver = false;

        foreach (EnemyController enemy in enemyControllers)
        {
            if (enemy.isPlayer) // �G���v���C���[�ɐG�ꂽ�ꍇ
            {
                isGameOver = true;
                break; // �����𖞂��������_�Ń��[�v�I��
            }
        }

        if (isGameOver || itemController.isGameOver == true) // �A�C�e�����n�ʂɗ������ꍇ���܂�
        {
            onGameOver.Invoke();
            Debug.Log("AAA");
        }

        // �Q�[���N���A����: �A�C�e�����n�ʂɗ�����O�Ƀv���C���[���G���
        if (itemController.isGameClear == true)
        {
            onGameClear.Invoke();
            Debug.Log("aaaa");
        }
    }
}
