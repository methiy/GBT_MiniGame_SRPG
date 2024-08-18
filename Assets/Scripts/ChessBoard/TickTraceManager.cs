using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickTraceManager : MonoBehaviour
{
    public static TickTraceManager Instance { get; private set; }
    [SerializeField] private GameObject originUnit;
    private Transform currentTarget;
    public Cell currentCell;
    public Unit currentCellUnit;
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
        if (currentTarget.TryGetComponent<Cell>(out Cell cell))
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
            switch (GameFlowStateManager.Instance.GetCurrentState())
            {
                case BeginPlayState:
                    currentCell.High();
                    break;
                case MoveCardState:
                    currentCell.PreSelect();
                    break;
            }
            
        }
        else
        {
            if (currentCell != null)
            {
                if(GameFlowStateManager.Instance.GetCurrentState() is BeginPlayState)
                {
                    currentCell.Normal();
                }
                else
                {
                    currentCell.UnSelect();
                }
                currentCell = null;
            }
        }
    }
    private void TraceCellUnit()
    {
        if (currentTarget.TryGetComponent<Unit>(out Unit unit))
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
