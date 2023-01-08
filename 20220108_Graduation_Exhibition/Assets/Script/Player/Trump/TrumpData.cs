using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create TrumpData")]
public class TrumpData : ScriptableObject
{
    [SerializeField]    // 挙動スピード
    private float trumpSpeed;
    public float TrumpSpeed{get{return trumpSpeed;}private set{trumpSpeed = value;}}

    
    [SerializeField]    // 消える時間(nミリ秒)
    private int deleteTime;
    public int DeleteTime{get{return deleteTime;}private set{deleteTime = value;}}
}
