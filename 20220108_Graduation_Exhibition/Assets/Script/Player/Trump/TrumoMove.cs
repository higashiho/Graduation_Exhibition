using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 

public class TrumoMove
{
    public static TrumoMove MoveTrump{get;private set;} = new TrumoMove();

    public void Move(BaseTrump trump)
    {
        // 弾に速度を与える
        trump.GetComponent<Rigidbody2D>().velocity = trump.ShotForward * trump.TrumpsData.TrumpSpeed;
    }

    public async UniTask Callback(BaseTrump tmpObj, TrumpData trumpData)
    {
        await UniTask.Delay(trumpData.DeleteTime);

        // オブジェクトプールに回収
        tmpObj.objectPoolCallBack?.Invoke(tmpObj);
    }
}
