using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public float maxHp;
    private float hp;
    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            EventManager.Instance.TriggerEvent(EventName.OnPlayerHPChangedEvent, this);
        }
    }
    public static Player Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        HP = maxHp;
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}
