using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateSystem : MonoBehaviour
{
    public abstract void Enter(StateSystem oldState = null);
    public abstract void Leave(StateSystem newState = null);
    public abstract void Execute();
}
