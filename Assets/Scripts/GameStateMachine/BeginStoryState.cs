using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginStoryState : StateSystem
{
    public override void Enter(StateSystem oldState = null)
    {
        TickTraceManager.Instance.gameObject.SetActive(false);
    }

    public override void Execute()
    {

    }

    public override void Leave(StateSystem newState = null)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
