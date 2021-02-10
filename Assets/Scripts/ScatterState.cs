using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AISTATE;
/// <summary>
/// State that creates "random" movement
/// </summary>
public class ScatterState : State<AI>
{
    private static ScatterState _instance;
    public MinotaurController minotaur;
    public float timer = 7;
    private ScatterState()
    {
        // first and ONLY time this gets constructed, we set 'this' instance = state.
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }


    //function to access a static instance of this state
    public static ScatterState Instance
    {
        get
        {
            if (_instance == null)
            {
                new ScatterState();
            }
            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        minotaur = _owner.minotaur;
    }

    public override void ExitState(AI _owner)
    {
    }

    public override void UpdateState(AI _owner)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            //Debug.Log(timer);
        }
        else if (timer <= 0)
            _owner.stateMachine.ChangeState(ScatterState.Instance);
    }
}
