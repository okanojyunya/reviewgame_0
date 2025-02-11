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
    GameObject enemy;
    GameObject item;
    /// <summary>プレイヤーについているスクリプト</summary>
    PlayerController playerController;
    /// <summary>敵についているスクリプト</summary>
    EnemyController enemyController;
    /// <summary>アイテムについているスクリプト</summary>
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
        //ゲームオーバー条件 > itemが地面に落ちたときとプレイヤーが死んだとき
        //playerControllerでプレイヤーの状態をフラグで管理する
        if (enemyController.isPlayer == true || itemController.isGameOver == true)
        {
            GameOver();
        }
        //ゲームクリア条件 > itemが地面に落ちる前にプレイヤーが触れる
        if (itemController.isGameClear == true)
        {
            onGameClear.Invoke();
        }

    }
    /// <summary>
    /// ゲームオーバーの条件が揃ったら実行する処理
    /// </summary>
    public void GameOver()
    {
        onGameOver.Invoke();
        Debug.Log("aa");
    }
}
