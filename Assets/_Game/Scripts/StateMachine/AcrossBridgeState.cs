using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrossBridgeState : IState
{
    public void OnEnter(Bot bot)
    {
    }

    public void OnExecute(Bot bot)
    {
        bot.AcrossBridge();
        if (bot.listBrick.Count == 0)
        {
            bot.ChangeState(new PickBrickState());
        }   
    }

    public void OnExit(Bot bot)
    {
            bot.StopMoving();
    }
}