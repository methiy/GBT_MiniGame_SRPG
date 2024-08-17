using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCardState : StateSystem
{
    public override void Enter(StateSystem oldState = null)
    {
        if(oldState == GameFlowStateManager.Instance.enemyState || oldState == GameFlowStateManager.Instance.beginState)
        {
            print("÷ÿ÷√≤Ω ˝");
            PlayerProps.Instance.RestStep();
        }
        EventManager.Instance.TriggerEvent(EventName.DrawCardEvent,this, new OnDrawCardArgs
        {
            cardType = CardType.MoveCard
        });
    }

    public override void Execute()
    {
        
    }

    public override void Leave(StateSystem newState = null)
    {
        EventManager.Instance.TriggerEvent(EventName.HideCardAreaEvent, this);
    }
}
