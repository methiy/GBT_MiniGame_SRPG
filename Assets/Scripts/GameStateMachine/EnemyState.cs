using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : StateSystem
{
    public override void Enter(StateSystem oldState = null)
    {
        EventManager.Instance.TriggerEvent(EventName.EnemyCalculateDamage, this);
        EventManager.Instance.TriggerEvent(EventName.OnEnemyMoveEvent, this);
    }

    public override void Execute()
    {

    }

    public override void Leave(StateSystem newState = null)
    {

    }
}
