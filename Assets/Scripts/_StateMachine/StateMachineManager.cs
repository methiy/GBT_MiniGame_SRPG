using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class StateMachineManager : MonoBehaviour
{
    protected StateSystem currentState;
    public bool GoToState(StateSystem newState)
    {
        StateSystem lastState = this.currentState;
        if(this.currentState)
        {
            this.currentState.Leave(newState);
        }
        this.currentState = newState;
        this.currentState.Enter(lastState);
        print("StateMathineSystem GotoStateEvent from " + lastState + " to " + newState);
        return true;
    }
    public void Execute()
    {
        this.currentState.Execute();
    }
}
