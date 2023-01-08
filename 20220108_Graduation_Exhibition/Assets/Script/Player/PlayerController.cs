using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
        PlayerMove.MovePlayer.Move(this.gameObject, playerData);
        PlayerMove.MovePlayer.Junp(this.gameObject, playerData);

        // トランプ生成挙動
        CreateTrump.TrumpCreate.TrumpMove(this.gameObject, trump);
    }
}
