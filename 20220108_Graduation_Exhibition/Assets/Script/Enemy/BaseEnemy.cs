using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{
    // エネミーの状態
    public enum EnemyState
    {
        MOVE,
        ATTACK,
        CHANGE
    }
    [SerializeField]
    protected EnemyState enemyStatus;
    public EnemyState EnemysStatus{get{return enemyStatus;}set {enemyStatus = value;}}

    // どっちに移動するかフラグ
    public enum EnemyMoveFlag
    {
        DEFAULT,
        LEFT,
        RIGHT
    } 
    [SerializeField]
    protected EnemyMoveFlag enemyMoveFlag = EnemyMoveFlag.DEFAULT;
    public EnemyMoveFlag EnemyMoveFlags{get {return enemyMoveFlag;}set {enemyMoveFlag = value;}}

    // エネミーのデータ
    [SerializeField]
    protected EnemyData enemyData;
    public EnemyData EnemysData{get{return enemyData;}private set{enemyData = value;}}
}
