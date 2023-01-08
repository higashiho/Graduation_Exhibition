using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColTrump : MonoBehaviour
{
    [SerializeField]
    private BaseTrump trump;
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Wall")
        {
            // 非同期をキャンセルしてプールに格納
            trump.cts.Cancel();
            
            trump.objectPoolCallBack?.Invoke(trump);
        }
    }
}
