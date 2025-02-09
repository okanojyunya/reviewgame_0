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

    [SerializeField] UnityEvent onStop;
    GameObject player;
    /// <summary>プレイヤーについているスクリプト</summary>
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
