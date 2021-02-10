using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AISTATE;
using System;
/// <summary>
/// Initilized state, ensures that a state is always loaded
/// </summary>
public class NeutralState : State<AI>
{
    private static NeutralState _instance;
    public MinotaurController minotaur;
    public float timer = 7;

    private NeutralState()
    {
        // first and ONLY time this gets constructed, we set 'this' instance = state.
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }


    //function to access a static instance of this state
    public static NeutralState Instance
    {
        get
        {
            if (_instance == null)
            {
                new NeutralState();
            }
            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        minotaur = _owner.minotaur;
        timer = 7;
        Debug.Log("ayy lmao");
    }

    public override void ExitState(AI _owner)
    {
        timer = 7;
        Debug.Log("peace");
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
            _owner.stateMachine.ChangeState(ChasingState.Instance);
    }
}
