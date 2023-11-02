using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBrickState : IState
{
    float timer;
    float randomTime;
    public void OnEnter(Bot bot)
    {
        timer = 0;
        randomTime = Random.Range(10, 20f);
        bot.navMeshAgent.isStopped = false;
    }

    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        bot.PickBrick();
        if (timer > randomTime) 
        {
            bot.ChangeState(new AcrossBridgeState());
        }
    }

    public void OnExit(Bot bot)
    {
    }
}
