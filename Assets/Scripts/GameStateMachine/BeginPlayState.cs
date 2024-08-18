using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPlayState : StateSystem
{
    [SerializeField] private GameObject originUnit;
    public override void Enter(StateSystem oldState = null)
    {
        TickTraceManager.Instance.bCanTraceCell = true;
    }

    public override void Execute()
    {
        if (TickTraceManager.Instance.currentCell != null)
        {
            GameObject clone = Instantiate(originUnit);
            clone.GetComponent<CellUnit>().SetCell(TickTraceManager.Instance.currentCell);
            GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.moveCardState);
        }
    }

    public override void Leave(StateSystem newState = null)
    {
        TickTraceManager.Instance.bCanTraceCell = false;
        //EventManager.Instance.TriggerEvent(EventName.OnGrabObjectEndEvent, this);
    }
}
