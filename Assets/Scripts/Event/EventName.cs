using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventName
{
    public const string OnGrabObjectPutDownEvent = nameof(OnGrabObjectPutDownEvent);
    public const string OnGrabObjectBeginEvent = nameof(OnGrabObjectBeginEvent);
    public const string OnGrabObjectEndEvent = nameof(OnGrabObjectEndEvent);
    public const string OnChangeGameFlowStateMachineEvent = nameof(OnChangeGameFlowStateMachineEvent);
    public const string CardSelectedEvent = nameof(CardSelectedEvent);
    public const string OnPlayerHPChangedEvent = nameof(OnPlayerHPChangedEvent);
    public const string OnEnemyHPChangedEvent = nameof(OnEnemyHPChangedEvent);
    public const string OnGameOverEvent = nameof(OnGameOverEvent);
    public const string OnEnemyCreateEvent = nameof(OnEnemyCreateEvent);
}
