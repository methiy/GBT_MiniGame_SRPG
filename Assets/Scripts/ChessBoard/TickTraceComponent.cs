using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PutDown,
    Select,
    Move,
}
public class TickTraceComponent : MonoBehaviour
{
    [SerializeField] private GameObject originUnit;
    private Transform currentTarget;
    private Cell currentCell;
    private CellUnit currentCellUnit;
    private GameState state = GameState.PutDown;

    private void Update()
    {
        TickTrace();
        MouseInput();
    }
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (state)
            {
                case GameState.PutDown:
                    if (currentCell != null)
                    {
                        GameObject clone = Instantiate(originUnit);
                        clone.GetComponent<CellUnit>().SetCell(currentCell);
                        state = GameState.Select;
                    }
                    break;
                case GameState.Select:
                    if (currentCellUnit != null)
                    {
                        currentCellUnit.Selected();
                        state = GameState.Move;
                    }
                    break;
                case GameState.Move:
                    if (currentCell != null)
                    {
                        currentCellUnit.SetCell(currentCell);
                    }

                    break;
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
            if (currentTarget.TryGetComponent<Cell>(out Cell cell))
            {
                if (currentCell != null && currentCell != cell)
                {
                    currentCell.Normal();
                }
                currentCell = cell;
                currentCell.High();
            }

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
                    //currentCellUnit = null;
                }
            }
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

    private void TogglePutDownToSelect()
    {
        state = GameState.Select;
        if (currentCell != null)
        {
            currentCell.Normal();
            currentCell = null;
        }
    }

    private void ToggleSelectToPutDown()
    {
        state = GameState.PutDown;
        if (currentCellUnit != null)
        {
            currentCellUnit.UnSelect();
            currentCellUnit = null;
        }
    }
}
