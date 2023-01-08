using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrump
{
    public static CreateTrump TrumpCreate{get;private set;} = new CreateTrump();

    
    // 弾の生成と移動向きを代入する関数
    public void TrumpMove(GameObject obj, BaseTrump trump)
    {
        if(Input.GetMouseButtonDown(0))
        {
            // 生成
            BaseTrump clone = FactoryTrump.objectPool.Launch(obj.transform.position, FactoryTrump.objectPool.BulletList, trump);

            // クリックした座標の取得（スクリーン座標からワールド座標に変換）
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 向きの生成（Z成分の除去と正規化）
            clone.ShotForward = Vector3.Scale((mouseWorldPos - obj.transform.position), new Vector3(1, 1, 0)).normalized;

            // トランプの挙動
            TrumoMove.MoveTrump.Move(clone);
        }
    }
}
