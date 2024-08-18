using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickTraceManager : MonoBehaviour
{
    public static TickTraceManager Instance { get; private set; }
    [SerializeField] private GameObject originUnit;
    private Transform currentTarget;
    public Cell currentCell;
    public CellUnit currentCellUnit;
    public bool bCanTraceCell = true;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        TickTrace();
        MouseInput();
    }
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameFlowStateManager.Instance.Execute();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (currentCellUnit != null && currentCellUnit.state == UnitState.PreSelect)
            {
                currentCellUnit.Selected();
            }
        }
    }
    private void TickTrace()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit))
        {
            currentTarget = hit.transform;
            TraceCell();
            TraceCellUnit();
        }
    }
    private void TraceCell()
    {
        if (bCanTraceCell && currentTarget.TryGetComponent<Cell>(out Cell cell))
        {
            if (!cell.bCanSelect)
            {
                return;
            }
            if (currentCell != null && currentCell != cell)
            {
                currentCell.Normal();
            }
            currentCell = cell;
            currentCell.High();
        }
        else
        {
            if (currentCell != null)
            {
                currentCell.Normal();
                currentCell = null;
            }
        }
    }
    private void TraceCellUnit()
    {
        if (currentTarget.TryGetComponent<CellUnit>(out CellUnit unit))
        {
            if (currentCellUnit != null && currentCellUnit != unit)
            {
                currentCellUnit.UnSelect();
            }
            currentCellUnit = unit;
            currentCellUnit.PreSelect();
        }
        else
        {
            if (currentCellUnit != null)
            {
                currentCellUnit.UnSelect();
            }
        }
    }
}
