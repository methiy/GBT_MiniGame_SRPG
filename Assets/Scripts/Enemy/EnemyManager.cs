using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private List<ChessBoardGrid> boardList;

    private void Start()
    {
        for(int i = 0;i< enemyList.Count; i++)
        {
            var grid = boardList[i].GetComponent<ChessBoardGrid>().SetLockGO(enemyList[i].gameObject);
            enemyList[i].SetCurrentGrid(grid);
        }
    }
}
