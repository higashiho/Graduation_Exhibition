using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 

public class ColTrump : MonoBehaviour
{
    [SerializeField]
    private BaseTrump trump;

    // ループフラグ
    private bool loopFlag = false;

    // プレイヤーとエネミー入れ替え関数
    private async void changePos(Collision2D col )
    {
        var tmpEnemy = col.gameObject.GetComponent<BaseEnemy>();
        // プレイヤーの座標とエネミーの座標を変更
        // プレイヤーの座標を一旦別変数に格納
        var tmpPlayerPos = PlayerController.player.transform.position;
        var tmpEnemyPos = tmpEnemy.transform.position;
        
        // 当たり判定
        var tmpPlayerCol = PlayerController.player.GetComponent<BoxCollider2D>();
        var tmpEnemyCol = tmpEnemy.GetComponent<BoxCollider2D>();
        var tmpPlayerRb = PlayerController.player.GetComponent<Rigidbody2D>();
        var tmpEnemyRb = tmpEnemy.GetComponent<Rigidbody2D>();

        
        // 座標を更新している最中は当たり判定と重力を削除
        tmpPlayerCol.enabled = false;
        tmpPlayerRb.gravityScale = 0;
        tmpEnemyCol.enabled = false;
        tmpEnemyRb.gravityScale = 0;

        // 処理中はステートを更新
        PlayerController.player.PlayerStatus = BasePlayer.PlayerState.CHANGE;
        tmpEnemy.EnemysStatus = BaseEnemy.EnemyState.CHANGE;

        // 座標を更新 指定秒後に処理終了
        while(true)
        {
            // 指定秒後に抜ける
            if(loopFlag)
            {
                loopFlag = false;
                break;
            }
            // 座標を更新
            PlayerController.player.transform.position = Vector3.MoveTowards(PlayerController.player.transform.position, tmpEnemyPos, Const.CHANGE_SPEED * Time.deltaTime);
            tmpEnemy.transform.position = Vector3.MoveTowards(tmpEnemy.transform.position, tmpPlayerPos, Const.CHANGE_SPEED * Time.deltaTime);
            await UniTask.Delay(Const.CHANGE_DELAY_SPEED);
        }

        // 処理が終わったらステートを初期化
        PlayerController.player.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
        tmpEnemy.EnemysStatus = BaseEnemy.EnemyState.MOVE;
        
        // 処理が終わるころに当たり判定と重力を直す
        tmpPlayerCol.enabled = true;
        tmpPlayerRb.gravityScale = Const.START_GRACITY_SCALE;
        tmpEnemyCol.enabled = true;
        tmpEnemyRb.gravityScale = Const.START_GRACITY_SCALE;
    }

    // 当たり判定
    private async void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Wall")
        {
            // 非同期をキャンセルしてプールに格納
            trump.cts.Cancel();
            
            trump.objectPoolCallBack?.Invoke(trump);
        }

        if(col.gameObject.tag == "Enemy")
        {
            // 位置変更
            changePos(col);

            // 非同期をキャンセルしてプールに格納
            trump.cts.Cancel();
            trump.objectPoolCallBack?.Invoke(trump);

            // 一定秒後にtrueに変換
            loopFlag = await endLoop();
        }
    }

    // 指定秒後にtrueを返すタスク
    private async UniTask<bool> endLoop()
    {
        // 0.8秒後にtrueを返す
        await UniTask.Delay((int)((float)Const.CHANGE_SECOND * Const.CHARACTER_CHANGE_TIME));
        return true;
    }
}
