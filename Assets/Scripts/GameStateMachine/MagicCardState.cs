using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCardState : StateSystem
{
    public override void Enter(StateSystem oldState = null)
    {
    }

    public override void Execute()
    {
        if (TickTraceManager.Instance.currentCell == null)
        {
            return;
        }
        print("³öÊõ·¨ÅÆ");
    }

    public override void Leave(StateSystem newState = null)
    {
        MapManager.Instance.LockCells();
    }
}
