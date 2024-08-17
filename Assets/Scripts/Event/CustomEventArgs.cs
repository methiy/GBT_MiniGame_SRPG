using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGrabObjectPutDownArgs : EventArgs
{
    public Vector3 putPosition;
}
public enum CardType
{
    MoveCard,
    MagicCard,
}
public class OnDrawCardArgs : EventArgs
{
    public CardType cardType;
}
