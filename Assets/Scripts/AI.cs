using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AISTATE;
/// <summary>
/// A collection of methods and booleans designed to influence the minotaur choice in state
/// </summary>
public class AI : MonoBehaviour
{
    public float gameTimer;
    public MinotaurController minotaur;
    public StateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        stateMachine = new StateMachine<AI>(this);
        minotaur = GetComponent<MinotaurController>();

        stateMachine.ChangeState(NeutralState.Instance);
        gameTimer = Time.time;
    }

    private void Update()
    {
        stateMachine.Update();
    }



}
