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

    }

    public override void Leave(StateSystem newState = null)
    {
        MapManager.Instance.LockCells();
    }
}
