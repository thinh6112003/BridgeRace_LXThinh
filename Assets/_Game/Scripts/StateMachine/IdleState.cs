using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float timer;
    float randomTime;
    public void OnEnter(Bot bot)
    {
        timer = 0;
        randomTime = Random.Range(0f, 0.5f);
    }

    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            bot.ChangeState(new PickBrickState());
        }
    }

    public void OnExit(Bot bot)
    {
    }
}
