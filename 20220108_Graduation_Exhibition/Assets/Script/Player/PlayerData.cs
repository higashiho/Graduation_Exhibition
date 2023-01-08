using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create PlayerData")]
public class PlayerData : ScriptableObject
{
    // 挙動スピード
    [SerializeField]
    private float playerSpeed;
    public float PlayerSpeed{get{return playerSpeed;}private set{playerSpeed = value;}}

    // ジャンプ力
    [SerializeField]
    private float playerJunpPower;
    public float PlayerJunpPower{get{return playerJunpPower;}private set{playerJunpPower = value;}}

    // ジャンプフラグ
    private bool junpFlag;
    public bool JunpFlag{get {return junpFlag;}set {junpFlag = value;}} 
    // ジャンプフラグを折るタイマー
    [SerializeField]
    private int junpFlagTimer;       // nミリ秒;
    public int JunpFlagTimer{get{return junpFlagTimer;}private set{junpFlagTimer = value;}}

}
