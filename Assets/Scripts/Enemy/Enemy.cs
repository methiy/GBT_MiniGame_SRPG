using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    private ChessBoardGrid currentGrid;
    private void Start()
    {
        EventManager.Instance.AddListener(EventName.OnChangeGameFlowStateMachineEvent, OnChangeGameFlowStateMachine);
    }
    public void SetCurrentGrid(ChessBoardGrid grid)
    {
        this.currentGrid = grid;
    }
    
    private void OnChangeGameFlowStateMachine(object sender,EventArgs e)
    {
        var args = e as OnChangeGameFlowStateMachineArgs;
        if(args.newState == GameFlowStateManager.Instance.enemyState)
        {
            CalculateDamage();
            Move();
        }
    }
    private void CalculateDamage()
    {
        print("结算伤害");
    }
    private void Move()
    {
        print("该移动了");
    }
}
