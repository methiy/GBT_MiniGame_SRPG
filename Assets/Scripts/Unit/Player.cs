using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public float maxHp;
    public AudioClip clip;
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
        ClipManager.Instance.PlayClip(clip);
        HP -= damage;
        if (HP <= 0)
        {
            EventManager.Instance.TriggerEvent(EventName.OnGameOverEvent, this, new OnGameOverEventArgs
            {
                bIsWin = false
            });
            GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.endState);
        }
    }
}
