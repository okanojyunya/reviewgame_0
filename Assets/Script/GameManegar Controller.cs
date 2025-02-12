using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ゲームを管理する。適当なオブジェクトにアタッチして各種設定をすれば動作可能
/// </summary>
public class GameManegarController : MonoBehaviour
{
    [Tooltip("プレイヤーが動いたときにする処理")]
    [SerializeField] UnityEvent onMoved;
    [Tooltip("プレイヤーが止まった時にする処理")]
    [SerializeField] UnityEvent onStop;
    [Tooltip("ゲームオーバーしたときにする処理")]
    [SerializeField] UnityEvent onGameOver;
    [Tooltip("ゲームクリアしたときにする処理")]
    [SerializeField] UnityEvent onGameClear;

    GameObject player;
    GameObject item;

    /// <summary>プレイヤーについているスクリプト</summary>
    PlayerController playerController;
    /// <summary>アイテムについているスクリプト</summary>
    ItemController itemController;

    /// <summary>すべての敵オブジェクト</summary>
    List<EnemyController> enemyControllers = new List<EnemyController>();

    private void Start()
    {
        // プレイヤーとアイテムを取得
        player = GameObject.Find("Player Body");
        item = GameObject.FindWithTag("Item");

        playerController = player.GetComponent<PlayerController>();
        itemController = item.GetComponent<ItemController>();

        // すべての敵オブジェクトを取得し、EnemyControllerをリストに追加
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
        // プレイヤーが動いたかどうかのチェック
        if (playerController.isMoved)
        {
            onMoved.Invoke();
        }
        else
        {
            onStop.Invoke();
        }

        // ゲームオーバー条件: いずれかの敵がisPlayer == true または itemが地面に落ちた場合
        bool isGameOver = false;

        foreach (EnemyController enemy in enemyControllers)
        {
            if (enemy.isPlayer) // 敵がプレイヤーに触れた場合
            {
                isGameOver = true;
                break; // 条件を満たした時点でループ終了
            }
        }

        if (isGameOver || itemController.isGameOver == true) // アイテムが地面に落ちた場合も含む
        {
            onGameOver.Invoke();
            Debug.Log("AAA");
        }

        // ゲームクリア条件: アイテムが地面に落ちる前にプレイヤーが触れる
        if (itemController.isGameClear == true)
        {
            onGameClear.Invoke();
            Debug.Log("aaaa");
        }
    }
}
