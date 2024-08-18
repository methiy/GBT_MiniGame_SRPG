using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCardState : StateSystem
{
    private bool bGotoMagic = true;
    public override void Enter(StateSystem oldState = null)
    {
        if (oldState == GameFlowStateManager.Instance.enemyState || oldState == GameFlowStateManager.Instance.beginState)
        {
            bGotoMagic = true;
            PlayerProps.Instance.RestStep();
        }
        else
        {
            bGotoMagic = false;
        }
    }

    public override void Execute()
    {
        if (TickTraceManager.Instance.currentCell == null)
        {
            return;
        }
        Unit unit = GameObject.FindObjectOfType<Unit>();
        unit.SetCell(TickTraceManager.Instance.currentCell);
        if (bGotoMagic)
        {
            GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.magicCardState);
        }
        else
        {
            GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.enemyState);
        }
    }

    public override void Leave(StateSystem newState = null)
    {
        MapManager.Instance.LockCells();
    }
}
