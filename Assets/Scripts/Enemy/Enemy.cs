using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    private ChessBoardGrid currentGrid;
    private void Start()
    {
        EventManager.Instance.AddListener(EventName.EnemyCalculateDamage, OnCalculateDamage);
        EventManager.Instance.AddListener(EventName.OnEnemyMoveEvent,OnMove);
    }
    public void SetCurrentGrid(ChessBoardGrid grid)
    {
        this.currentGrid = grid;
    }
    
    private void OnMove(object obj,EventArgs e)
    {
        print("该移动了");
    }
    private void OnCalculateDamage(object obj,EventArgs e)
    {
        print("结算伤害");
    }
}
