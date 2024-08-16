using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPlayState : StateSystem
{
    [SerializeField] private GameObject player;
    public override void Enter(StateSystem oldState = null)
    {
        GrabManager.Instance.UpdateGrabMesh(player);
    }

    public override void Execute()
    {
    }

    public override void Leave(StateSystem newState = null)
    {
    }
}
