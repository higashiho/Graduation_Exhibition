using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseEnemy
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(enemyStatus)
        {
            // 移動挙動
            case EnemyState.MOVE:
                EnemyMove.enemyMove.Move(this);
                break;
            // 攻撃挙動
            case EnemyState.ATTACK:
                break;
            // プレイヤーとの座標変更時
            case EnemyState.CHANGE:
                break;
            default:
                break;
        }
    }
}
