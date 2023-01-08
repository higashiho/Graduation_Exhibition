using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public enum PlayerState
    {
        DEFAULT,
        MOVE,
        JUMP,
    }
    protected PlayerState playerStatus = PlayerState.DEFAULT;
    public PlayerState PlayerStatus{get{return playerStatus;}set {playerStatus = value;}}

    // 入力関係
    protected void imput()
    {
        // 移動ボタンを押されたらステート更新
        if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            playerStatus = PlayerState.MOVE;

        // ジャンプボタンを押されたらステート更新
        if(Input.GetKeyDown(KeyCode.Space))
            playerStatus = PlayerState.JUMP;
        
    }
}
