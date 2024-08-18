using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameFlowStateManager : StateMachineManager
{
    public static GameFlowStateManager Instance;
    public BeginPlayState beginState;
    public MoveCardState moveCardState;
    public MagicCardState magicCardState;
    public EnemyState enemyState;
    public EndPlayState endState;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        this.GoToState(beginState);

        //EventManager.Instance.AddListener(EventName.OnGrabObjectPutDownEvent, (object sender, EventArgs e) =>
        //{
        //    if(this.currentState == beginState)
        //    {
        //        this.GoToState(moveCardState);
        //    }
        //});
    }
    public override bool GoToState(StateSystem newState)
    {
        EventManager.Instance.TriggerEvent(EventName.OnChangeGameFlowStateMachineEvent, this, new OnChangeGameFlowStateMachineArgs
        {
            oldState = currentState,
            newState = newState
        });
        return base.GoToState(newState);
    }
}
