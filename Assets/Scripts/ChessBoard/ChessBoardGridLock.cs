using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChessBoardGridLock : MonoBehaviour
{
    [SerializeField] private Transform selfGO;

    private Vector3 putPosition;
    private void Start()
    {
        putPosition = new Vector3(selfGO.transform.position.x,selfGO.transform.position.y+selfGO.transform.GetComponent<Renderer>().bounds.size.y, selfGO.transform.position.z);
    }

    private void OnMouseEnter()
    {
        GrabManager.Instance.LockGrabGOOnGrid(putPosition);
    }
    
    private void OnMouseExit()
    {
        GrabManager.Instance.UnLockGrabGO();
    }

    private void OnMouseDown()
    {
        EventManager.Instance.TriggerEvent(EventName.OnGrabObjectPutDownEvent, this,new OnGrabObjectPutDownArgs
        {
            putPosition = this.putPosition,
        });
    }
}