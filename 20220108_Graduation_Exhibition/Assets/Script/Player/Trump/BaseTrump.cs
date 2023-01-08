using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;

public class BaseTrump : MonoBehaviour
{
    [SerializeField]    // データ
    protected TrumpData trumpData;
    public TrumpData TrumpsData{get{return trumpData;}private set{trumpData = value;}}

    // 移動向き
    protected Vector3 shotForward;  
    public Vector3 ShotForward{get{return shotForward;}set{shotForward = value;}}

    // 時間計測
    protected float time;
    public float TimeManage{get{return time;}set {time = value;}}


    // 回収イベント
    public UnityAction<BaseTrump> objectPoolCallBack;

    
    public CancellationTokenSource cts{get;private set;} = new CancellationTokenSource();  
}
