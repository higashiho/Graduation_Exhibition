using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // プレイヤー取得用
    public static PlayerController player{get;private set;} = null;
    [SerializeField]
    private PlayerMove movePlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = this;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤー挙動関係
        movePlayer.Move(this.gameObject);
        movePlayer.Junp(this.gameObject);
    }
}
