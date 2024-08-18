using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyPropsPanelUI : MonoBehaviour
{
    [SerializeField] private EnemyPropsTemplateUI enemyProp;
    public static EnemyPropsPanelUI Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        EventManager.Instance.AddListener(EventName.OnEnemyCreateEvent, OnEnemyCreate);
    }
    private void Start()
    {
        EventManager.Instance.AddListener(EventName.OnEnemyCreateEvent, OnEnemyCreate);
    }
    private void OnEnemyCreate(object obj,EventArgs e)
    {
        var args = e as OnEnemyCreateEventArgs;
        var enemyPropUI = Instantiate(enemyProp);
        enemyPropUI.Init(args.enemy);
        enemyPropUI.transform.SetParent(transform);
    }
    public void AddChild(Enemy enemy)
    {
        var enemyPropUI = Instantiate(enemyProp);
        enemyPropUI.Init(enemy);
        enemyPropUI.transform.SetParent(transform);
    }
}
