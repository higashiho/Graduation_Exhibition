using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer
{
    // 挙動スピード
    protected float playerSpeed;

    // ジャンプ力
    protected float playerJunpPower;

    // ジャンプフラグ
    protected bool junpFlag;
    // ジャンプフラグを折るタイマー
    protected float junpFlagTImer;
}
