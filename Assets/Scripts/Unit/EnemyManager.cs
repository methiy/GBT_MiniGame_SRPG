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
            EnemyPropsPanelUI.Instance.AddChild(enemyList[i]);
        }
    }

    public void EnemyHandle()
    {
        foreach (Enemy enemy in enemyList)
        {
            CalculateDamage(enemy);
            MapManager.Instance.EnemyMove(enemy);
            if (MapManager.Instance.CanDamage(enemy))
            {
                print("ÔÚ¹¥»÷" + enemy.name + "·¶Î§ÄÚ");
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
