using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 



public class PlayerMove
{
    
    public static PlayerMove MovePlayer{get;private set;} = new PlayerMove();
    // プレイヤー挙動
    // 第一引数：動かすオブジェクト　第二引数：オブジェクトのデータ
    public void Move(GameObject obj, PlayerData playerData)
    {
        var pos = new Vector3();

        if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow))
            pos.x -= playerData.PlayerSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            pos.x += playerData.PlayerSpeed * Time.deltaTime;

        obj.transform.position += pos;
    }
    
    // ジャンプ挙動
    // 第一引数：動かすオブジェクト　第二引数：オブジェクトのデータ
    public async void Junp(GameObject obj, PlayerData playerData)
    {
        // フラグがたってなくてスペースを押された場合
        if(!playerData.JunpFlag && Input.GetKeyDown(KeyCode.Space))
        {
            playerData.JunpFlag = true;
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,playerData.PlayerJunpPower,0));
            // 1秒後にフラグを折る
            await junpCoolTime(playerData);
        }
    }
    
    // 一秒後にジャンプフラグを折る
    private async UniTask junpCoolTime(PlayerData playerData)  
    {
        await UniTask.Delay(playerData.JunpFlagTimer);  
        playerData.JunpFlag = false;
        Debug.Log("Unitask完了");  
    }
}
