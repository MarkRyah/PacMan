using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AISTATE;
/// <summary>
/// State that dictates chasing the player
/// </summary>
public class ChasingState : State<AI>
{
    private static ChasingState _instance;
    public MinotaurController minotaur;
    public float timer = 20;
    private ChasingState()
    {
        // first and ONLY time this gets constructed, we set 'this' instance = state.
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }


    //function to access a static instance of this state
    public static ChasingState Instance
    {
        get
        {
            if (_instance == null)
            {
                new ChasingState();
            }
            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        Debug.Log("CHASING");
        timer = 20;
    }

    public override void ExitState(AI _owner)
    {
    }

    public override void UpdateState(AI _owner)
    {
        //TODO remove following code and reimpliment into a proper init state
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            //Debug.Log(timer);
        }
        else if (timer <= 0)
            _owner.stateMachine.ChangeState(ScatterState.Instance);
    }
}
