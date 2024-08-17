using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPlayState : StateSystem
{
    private GameObject player;
    private void Start()
    {
        player = Player.Instance.gameObject;
    }
    public override void Enter(StateSystem oldState = null)
    {
        GrabManager.Instance.UpdateGrabGO(player);
        EventManager.Instance.TriggerEvent(EventName.OnGrabObjectBeginEvent, this);
    }

    public override void Execute()
    {
    }

    public override void Leave(StateSystem newState = null)
    {
        EventManager.Instance.TriggerEvent(EventName.OnGrabObjectEndEvent, this);
    }
}
