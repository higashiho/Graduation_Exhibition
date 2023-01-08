using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove
{
    public static EnemyMove enemyMove = new EnemyMove();
    public void Move(BaseEnemy enemy)
    {
        var tmpPos = enemy.transform.position;

        switch(enemy.EnemyMoveFlags)
        {
            case BaseEnemy.EnemyMoveFlag.LEFT:
                tmpPos.x -= enemy.EnemysData.EnemySpeed * Time.deltaTime;
                break;
            case BaseEnemy.EnemyMoveFlag.RIGHT:
                tmpPos.x += enemy.EnemysData.EnemySpeed * Time.deltaTime;
                break;
            default:
                break;
        }
        enemy.transform.position = tmpPos;
    }
}
