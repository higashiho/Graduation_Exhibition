using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TrumpController : BaseTrump
{
    
    async void OnEnable()
    {
        // 指定秒後に回収
        await TrumoMove.MoveTrump.Callback(this, trumpData, cts.Token);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
