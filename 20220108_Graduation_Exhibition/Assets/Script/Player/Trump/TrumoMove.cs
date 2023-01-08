using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using System.Threading;

public class TrumoMove
{
    public static TrumoMove MoveTrump{get;private set;} = new TrumoMove();

    public void Move(BaseTrump trump)
    {
        // 弾に速度を与える
        trump.GetComponent<Rigidbody2D>().velocity = trump.ShotForward * trump.TrumpsData.TrumpSpeed;
    }

    public async UniTask Callback(BaseTrump tmpObj, TrumpData trumpData, CancellationToken token)
    {
        await UniTask.Delay(trumpData.DeleteTime);

        // キャンセルが要求されている場合
        if ( token.IsCancellationRequested )
        {
            Debug.Log ( "Canceled." );
            return;
        }
        
        // されていない場合
        Debug.Log("pool格納");
        // オブジェクトプールに回収
        tmpObj.objectPoolCallBack?.Invoke(tmpObj);
    }
}
