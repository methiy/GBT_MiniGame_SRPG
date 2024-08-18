using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    //[SerializeField] private Dictionary<Enemy, Vector2> enemyList;
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private List<Vector2> enemyPosList;
    [SerializeField] private float ToggleTimer;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for(int i = 0;i < enemyList.Count; i++)
        {
            Cell cell = MapManager.Instance.GetCellFromIndex(enemyPosList[i]);
            enemyList[i].SetCell(cell);
            //EnemyPropsPanelUI.Instance.AddChild(enemyList[i]);
            EventManager.Instance.TriggerEvent(EventName.OnEnemyCreateEvent, this, new OnEnemyCreateEventArgs
            {
                enemy = enemyList[i]
            });
        }
        EventManager.Instance.AddListener(EventName.OnEnemyDestroyEvent, OnEnemyDestroy);
    }
    private void OnEnemyDestroy(object obj,EventArgs e)
    {
        if(enemyList.Count == 1)
        {
            print("胜利");
            EventManager.Instance.TriggerEvent(EventName.OnGameOverEvent, this, new OnGameOverEventArgs
            {
                bIsWin = true
            });
            return;
        }
        var enemy = obj as Enemy;
        var cell = enemy.GetCurrentCell();
        cell.bCanSpawn = true;
        print(enemy.name + "被消灭");
        enemyList.Remove(enemy);
        Destroy(enemy);
    }

    public void EnemyHandle()
    {
        foreach (Enemy enemy in enemyList)
        {
            CalculateDamage(enemy);
            MapManager.Instance.EnemyMove(enemy);
            if (MapManager.Instance.CanDamage(enemy))
            {
                print("在攻击" + enemy.name + "范围内");
                Player.Instance.TakeDamage(enemy.damage);
            }
        }

        DelayUtil();
    }

    public void DelayUtil()
    {
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(ToggleTimer);
        GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.moveCardState);
    }
    private void CalculateDamage(Enemy enemy)
    {
        int damage = enemy.GetCurrentCell().damage;
        if (damage > 0)
        {
            enemy.HP -= damage;
        }
    }
}
