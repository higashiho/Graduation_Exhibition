using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : BasePlayer
{
    
    PlayerMove()
    {
        playerSpeed = 8.0f;
        playerJunpPower = 200.0f;
        junpFlag = false;
        junpFlagTImer = 1.0f;
    }

    public static PlayerMove MovePlayer{get; private set;} = new PlayerMove();
    // プレイヤー挙動
    public void Move(GameObject obj)
    {
        var pos = new Vector3();

        if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow))
            pos.x -= playerSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            pos.x += playerSpeed * Time.deltaTime;

        obj.transform.position += pos;
    }

    public void Junp(GameObject obj)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            junpFlag = true;
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,playerJunpPower,0));
            
        }
    }


}
