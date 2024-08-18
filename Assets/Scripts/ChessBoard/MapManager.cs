using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    [SerializeField] private Cell originCell;
    [SerializeField] private float padding;
    [SerializeField] private int row;
    [SerializeField] private int col;
    [SerializeField] private int cellW;
    private Dictionary<Vector2, Cell> cellMatrix = new Dictionary<Vector2, Cell>();
    private readonly List<Vector2> dirList = new List<Vector2>
    {
        new(0,1),
        new(0,-1),
        new(1,0),
        new(-1,0),
    };
    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Cell cloneCell = Instantiate(originCell);
                cloneCell.transform.SetParent(transform);
                cloneCell.transform.position = transform.position + Vector3.right * cellW * j + Vector3.forward * cellW * i
                    + Vector3.right * padding * j + Vector3.forward * padding * i;
                Vector2 index = new(i, j);
                cloneCell.pos = index;
                cellMatrix.Add(index, cloneCell);
            }
        }
    }
    private void Start()
    {
        EventManager.Instance.AddListener(EventName.CardSelectedEvent, OnCardSelected);
    }

    private void OnCardSelected(object sender, EventArgs e)
    {
        var args = e as OnCardSelectedArgs;
        Unit currentCellUnit = GameObject.FindObjectOfType<Unit>();
        if (currentCellUnit != null)
        {
            this.HighCell(currentCellUnit.GetCurrentCell(), args.rangeList);
        }
    }

    public void HighCell(Cell cell,List<Vector2> indexList)
    {
        foreach(var index in indexList)
        {
            Vector2 tempIndex = new Vector2(cell.pos.x + index.x, cell.pos.y+index.y);
            if (cellMatrix.ContainsKey(tempIndex))
            {
                cellMatrix[tempIndex].bCanSelect = true;
                cellMatrix[tempIndex].High();
            }
        }
    }

    public void LockCells()
    {
        foreach( var cell in cellMatrix)
        {
            cell.Value.bCanSelect = false;
            cell.Value.Normal();
        }
    }
    public Cell GetCellFromIndex(Vector2 index)
    {
        return cellMatrix[index];
    }

    public bool CanDamage(Enemy enemy)
    {
        Vector2 enemyPos = enemy.GetCurrentCell().pos;
        Vector2 playerPos = Player.Instance.GetCurrentCell().pos;
        foreach(var atk in enemy.atkRange)
        {
            Vector2 atkPos = new(enemyPos.x + atk.x, enemyPos.y + atk.y);
            if(atkPos == playerPos)
            {
                return true;
            }       
        }
        return false;
    }
    public void EnemyMove(Enemy enemy)
    {
        var cell = enemy.GetCurrentCell();
        Vector2 enemyPos = cell.pos;
        Vector2 playerPos = Player.Instance.GetCurrentCell().pos;
        float oldDir = enemyPos.x - playerPos.x + enemyPos.y - playerPos.y;
        foreach (Vector2 dir in dirList)
        {
            Vector2 newPos = enemyPos + dir;
            float newDir = newPos.x - playerPos.x + newPos.y - playerPos.y;
            if (cellMatrix.ContainsKey(newPos) && newDir <= oldDir)
            {
                if (cellMatrix[newPos].bCanSpawn)
                {
                    print("发现新位置");
                    enemy.SetCell(cellMatrix[newPos]);
                }
            }
        }
        print("搜索完毕");
    }
}
