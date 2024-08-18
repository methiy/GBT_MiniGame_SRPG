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
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Cell cloneCell = Instantiate(originCell);
                cloneCell.transform.SetParent(transform);
                cloneCell.transform.position = transform.position + Vector3.right * cellW * j + Vector3.forward * cellW * i
                    + Vector3.right * padding * j + Vector3.forward * padding * i;
                cloneCell.x = i;
                cloneCell.y = j;
                Vector2 index = new Vector2(i, j);
                cellMatrix.Add(index,cloneCell);
            }
        }

        EventManager.Instance.AddListener(EventName.CardSelectedEvent, OnCardSelected);
    }

    private void OnCardSelected(object sender, EventArgs e)
    {
        var args = e as OnCardSelectedArgs;
        CellUnit currentCellUnit = GameObject.FindObjectOfType<CellUnit>();
        if (currentCellUnit != null)
        {
            this.HighCell(currentCellUnit.GetCurrentCell(), args.rangeList);
        }
        else
        {
            print("√ª’“µΩ");
        }
    }

    public void HighCell(Cell cell,List<Vector2> indexList)
    {
        foreach(var index in indexList)
        {
            Vector2 tempIndex = new Vector2(cell.x + index.x, cell.y+index.y);
            if (cellMatrix.ContainsKey(tempIndex))
            {
                cellMatrix[tempIndex].High();
            }
        }
    }
}
