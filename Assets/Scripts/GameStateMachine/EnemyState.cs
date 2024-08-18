using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : StateSystem
{
    public override void Enter(StateSystem oldState = null)
    {
        EnemyManager.Instance.EnemyHandle();
    }

    public override void Execute()
    {

    }

    public override void Leave(StateSystem newState = null)
    {

    }
}
