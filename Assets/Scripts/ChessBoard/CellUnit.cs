using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Idle,
    PreSelect,
    Selected
}
public class CellUnit : MonoBehaviour
{
    private Cell currentCell;
    private Outline outline;
    public UnitState state;

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    public void PreSelect()
    {
        if(state == UnitState.Selected)
        {
            return;
        }
        outline.enabled = true;
        outline.OutlineColor = Color.white;
        state = UnitState.PreSelect;
    }

    public void Selected()
    {
        state = UnitState.Selected;
        outline.OutlineColor = Color.green;
        // 显示选中UI
    }

    public void UnSelect()
    {
        outline.enabled = false;
        state = UnitState.Idle;
        // 清理选中UI
    }
    public void SetCell(Cell cell)
    {
        this.currentCell = cell;
        transform.position = cell.transform.position;
    }
    public Cell GetCurrentCell()
    {
        return currentCell;
    }
}
