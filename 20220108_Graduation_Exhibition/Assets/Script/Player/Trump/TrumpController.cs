using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : BaseTrump
{
    
    async void OnEnable()
    {
        // 指定秒後に回収
        await TrumoMove.MoveTrump.Callback(this, trumpData);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
