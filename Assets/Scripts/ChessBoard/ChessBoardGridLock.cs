using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChessBoardGridLock : MonoBehaviour
{
    [SerializeField] private Transform selfGO;

    private Vector3 putPosition;
    public void Start()
    {
        putPosition = new Vector3(selfGO.transform.position.x,selfGO.transform.position.y+selfGO.transform.GetComponent<Renderer>().bounds.size.y, selfGO.transform.position.z);
    }

    public void OnMouseEnter()
    {
        GrabManager.Instance.LockGrabGOOnGrid(putPosition);
    }
    
    public void OnMouseExit()
    {
        GrabManager.Instance.UnLockGrabGO();
    }

    public void OnMouseDown()
    {
        GrabManager.Instance.OnGrabGOPutDown();
        // TODO:转换状态机行为摆放相关的物件
        GameObject.Find("Player").gameObject.transform.position = putPosition;
    }
}