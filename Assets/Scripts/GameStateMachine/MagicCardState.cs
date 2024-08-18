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
            print("ø®≈∆…À∫¶£∫" + card.damage);
            currentDamage = card.damage;
        });
    }
    public override void Enter(StateSystem oldState = null)
    {
    }

    public override void Execute()
    {
        if (TickTraceManager.Instance.currentCell == null)
        {
            return;
        }

        if (TickTraceManager.Instance.currentCellUnit != null && TickTraceManager.Instance.currentCellUnit is Enemy) 
        {
            print(" Õ∑≈∑® ı");
            Enemy enemy = TickTraceManager.Instance.currentCellUnit as Enemy;
            enemy.TakeDamage(currentDamage);
        }
    }

    public override void Leave(StateSystem newState = null)
    {
        MapManager.Instance.LockCells();
    }
}
