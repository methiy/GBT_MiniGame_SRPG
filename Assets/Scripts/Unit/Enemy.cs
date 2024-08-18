using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private float hp;
    [SerializeField] private string enemyName;
    public List<Vector2> atkRange;
    public int damage;
    public float maxHp;
    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            EventManager.Instance.TriggerEvent(EventName.OnEnemyHPChangedEvent, this);
        }
    }
    private void Start()
    {
        maxHp = hp;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            EventManager.Instance.TriggerEvent(EventName.OnEnemyDestroyEvent, this);
            Destroy(gameObject);
        }
    }
}
