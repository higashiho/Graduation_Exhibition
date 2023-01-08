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
            case PlayerState.MOVE:
                PlayerMove.MovePlayer.Move(this, playerData);
                break;
            case PlayerState.JUMP:
                PlayerMove.MovePlayer.Junp(this, playerData);
                break;
            case PlayerState.DEFAULT:
                imput();
                break;
            default:
                break;
        }

        // トランプ生成挙動
        CreateTrump.TrumpCreate.TrumpMove(this.gameObject, trump);
    }

}
