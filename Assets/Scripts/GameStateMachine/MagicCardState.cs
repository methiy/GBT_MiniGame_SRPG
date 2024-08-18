using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCardState : StateSystem
{
    private int currentDamage;
    private void Start()
    {
        EventManager.Instance.AddListener(EventName.CardSelectedEvent, (object obj, EventArgs e) =>
        {
            var card = obj as CardTemplate;
            print("¿¨ÅÆÉËº¦£º" + card.damage);
            currentDamage = card.damage;
        });
    }
    public override void Enter(StateSystem oldState = null)
    {
    }

    public override void Execute()
    {
        if (TickTraceManager.Instance.currentCellUnit != null)
        {
            print("Ä¿±ê" + TickTraceManager.Instance.currentCellUnit);
        }
        if (TickTraceManager.Instance.currentCellUnit != null) 
        {
            if(TickTraceManager.Instance.currentCellUnit.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(currentDamage);
                GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.moveCardState);
            }
            
        }
    }

    public override void Leave(StateSystem newState = null)
    {
        MapManager.Instance.LockCells();
    }
}
