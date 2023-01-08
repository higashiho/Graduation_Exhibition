using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePlayer
{
    // プレイヤー取得用
    public static PlayerController player{get;private set;} = null;
    [SerializeField]
    private PlayerData playerData;

    [SerializeField]    // 生成するトランプ
    private BaseTrump trump;
    // Start is called before the first frame update
    void Start()
    {
        player = this;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤー挙動関係
        switch(playerStatus)
        {
            // 移動挙動
            case PlayerState.MOVE:
                PlayerMove.MovePlayer.Move(this, playerData);
                break;
            // ジャンプ挙動
            case PlayerState.JUMP:
                PlayerMove.MovePlayer.Junp(this, playerData);
                break;
            // 通常時
            case PlayerState.DEFAULT:
                imput();
                break;
            // エネミーとの座標変更時
            case PlayerState.CHANGE:
                break;
            default:
                break;
        }

        // 移動中と座標変更時はトランプ生成できないように設定
        if(playerStatus != PlayerState.MOVE || playerStatus != PlayerState.CHANGE)
            // トランプ生成挙動
            CreateTrump.TrumpCreate.TrumpMove(this.gameObject, trump);
    }

}
