using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColPlayer : MonoBehaviour
{
    // 当たり判定
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Bullet")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
