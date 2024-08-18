using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPlayState : StateSystem
{
    private GameObject originUnit;
    private void Start()
    {
        originUnit = Resources.Load<GameObject>("Prefabs/Player");
        if(originUnit == null)
        {
            print("加载玩家资源失败");
        }
    }
    public override void Enter(StateSystem oldState = null)
    {
        TickTraceManager.Instance.gameObject.SetActive(true);
    }

    public override void Execute()
    {
        if (TickTraceManager.Instance.currentCell != null)
        {
            GameObject clone = Instantiate(originUnit);
            clone.GetComponent<Player>().SetCell(TickTraceManager.Instance.currentCell);
            //clone.GetComponent<Unit>().SetCell(TickTraceManager.Instance.currentCell);
            GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.moveCardState);
        }
    }

    public override void Leave(StateSystem newState = null)
    {
        MapManager.Instance.LockCells();
    }
}
