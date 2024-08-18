using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropsPanelUI : MonoBehaviour
{
    [SerializeField] private EnemyPropsTemplateUI enemyProp;
    public static EnemyPropsPanelUI Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void AddChild(Enemy enemy)
    {
        var enemyPropUI = Instantiate(enemyProp);
        enemyPropUI.Init(enemy);
        enemyPropUI.transform.SetParent(transform);
    }
}
