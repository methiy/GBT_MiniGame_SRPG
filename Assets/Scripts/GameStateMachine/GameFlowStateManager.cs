using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowStateManager : StateMachineManager
{
    public static GameFlowStateManager Instance;
    [SerializeField] private BeginPlayState beginState;
    [SerializeField] private DuringPlayState duringState;
    [SerializeField] private EndPlayState endState;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        this.GoToState(beginState);

        EventManager.Instance.AddListener(EventName.OnGrabObjectPutDownEvent, (object sender, EventArgs e) =>
        {
            if(this.currentState == beginState)
            {
                this.GoToState(duringState);
            }
        });
    }

}
