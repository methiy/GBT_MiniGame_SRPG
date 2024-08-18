using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public enum UnitState
{
    Idle,
    PreSelect,
    Selected
}
public class Unit : MonoBehaviour
{
    protected Cell currentCell;
    private Outline outline;
    private UnitState state;

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
        if (!cell.bCanSpawn)
        {
            print("被设置在不可以重生的地方");
        }
        if (this.currentCell != null)
        {
            this.currentCell.bCanSelect = true;
            this.currentCell.bCanSpawn = true;
        }
        this.currentCell = cell;
        transform.position = cell.transform.position;
        cell.bCanSelect = false;
        cell.bCanSpawn = false;
    }
    public Cell GetCurrentCell()
    {
        return currentCell;
    }

    public bool IsPreSelect()
    {
        return state == UnitState.PreSelect;
    }
}
