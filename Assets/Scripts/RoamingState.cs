using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AISTATE;
/// <summary>
/// Initilized state, ensures that a state is always loaded
/// No state should swap back to this state
/// </summary>
public class RoamingState : State<AI>
{
    private static RoamingState _instance;
    public MinotaurController minotaur;

    private RoamingState()
    {
        // first and ONLY time this gets constructed, we set 'this' instance = state.
        if (_instance != null)
        {
            return;
        }
            _instance = this;
    }


    //function to access a static instance of this state
    public static RoamingState Instance
    {
        get
        {
            if (_instance == null)
            {
                new RoamingState();
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
        //TODO remove following code and reimpliment into a proper init state
        _owner.stateMachine.ChangeState(RoamingState.Instance);
    }
}
