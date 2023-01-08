using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 

public class ColTrump : MonoBehaviour
{
    [SerializeField]
    private BaseTrump trump;

    private async void changePos(Collision2D col)
    {
        // プレイヤーの座標とエネミーの座標を変更
        // プレイヤーの座標を一旦別変数に格納
        var tmpPlayerPos = PlayerController.player.transform.position;
        var tmpEnemyPos = col.transform.position;
        
        // 当たり判定
        var tmpPlayerCol = PlayerController.player.GetComponent<BoxCollider2D>();
        var tmpEnemyCol = col.gameObject.GetComponent<BoxCollider2D>();
        var tmpPlayerRb = PlayerController.player.GetComponent<Rigidbody2D>();
        var tmpEnemyRb = col.gameObject.GetComponent<Rigidbody2D>();

        
        // 座標を更新している最中は当たり判定と重力を削除
        tmpPlayerCol.enabled = false;
        tmpPlayerRb.gravityScale = 0;
        tmpEnemyCol.enabled = false;
        tmpEnemyRb.gravityScale = 0;

        // 処理中はステートを更新
        PlayerController.player.PlayerStatus = BasePlayer.PlayerState.CHANGE;

        // 座標を更新
        while(PlayerController.player.transform.position.x != tmpEnemyPos.x)
        {
            // 座標を更新
            PlayerController.player.transform.position = Vector3.MoveTowards(PlayerController.player.transform.position, tmpEnemyPos, Const.CHANGE_SPEED * Time.deltaTime);
            col.transform.position = Vector3.MoveTowards(col.transform.position, tmpPlayerPos, Const.CHANGE_SPEED * Time.deltaTime);
            await UniTask.Delay(Const.CHANGE_DELAY_SPEED);
        }

        // 処理が終わったらステートを初期化
        PlayerController.player.PlayerStatus = BasePlayer.PlayerState.DEFAULT;
        
        // 処理が終わるころに当たり判定と重力を直す
        tmpPlayerCol.enabled = true;
        tmpPlayerRb.gravityScale = Const.START_GRACITY_SCALE;
        tmpEnemyCol.enabled = true;
        tmpEnemyRb.gravityScale = Const.START_GRACITY_SCALE;
    }
    
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Wall")
        {
            // 非同期をキャンセルしてプールに格納
            trump.cts.Cancel();
            
            trump.objectPoolCallBack?.Invoke(trump);
        }

        if(col.gameObject.tag == "Enemy")
        {
            // 非同期をキャンセルしてプールに格納
            trump.cts.Cancel();
            trump.objectPoolCallBack?.Invoke(trump);

            // 位置変更
            changePos(col);
        }
    }
}
