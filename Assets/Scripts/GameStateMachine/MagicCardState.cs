using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCardState : StateSystem
{
    public override void Enter(StateSystem oldState = null)
    {
        EventManager.Instance.TriggerEvent(EventName.DrawCardEvent,this, new OnDrawCardArgs
        {
            cardType = CardType.MagicCard
        });
    }

    public override void Execute()
    {

    }

    public override void Leave(StateSystem newState = null)
    {

    }
}
