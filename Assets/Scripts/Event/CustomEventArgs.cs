using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGrabObjectPutDownArgs : EventArgs
{
    public Vector3 putPosition;
}

public class OnChangeGameFlowStateMachineArgs : EventArgs
{
    public StateSystem oldState;
    public StateSystem newState;
}
public class OnCardSelectedArgs : EventArgs
{
    public CardType cardType;
    public List<Vector2> rangeList;
}

public class OnGameOverEventArgs : EventArgs
{
    public bool bIsWin;
}
