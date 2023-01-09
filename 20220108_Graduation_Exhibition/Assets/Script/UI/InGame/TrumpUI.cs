using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpUI
{
    public static TrumpUI Trumps{get;private set;} = new TrumpUI();


    private bool playFlag = true;
    public  bool PlayFlag{get {return playFlag;}set {playFlag = value;}}

    // UIの挙動
    public void Move(BaseUI tmpUI)
    {
        // プレイヤーがトランプを打ったら再生
        if(!PlayerController.Player.ShotFlag && PlayFlag)
        {
            Debug.Log("play");
            tmpUI.TrumpAbunator.Play();
            PlayFlag = false;
        }
    }
}
