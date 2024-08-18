using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private int hp;
    [SerializeField] private string enemyName;
    public List<Vector2> atkRange;
    public int damage;
    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            EventManager.Instance.TriggerEvent(EventName.OnEnemyHPChangedEvent, this);
        }
    }
}
