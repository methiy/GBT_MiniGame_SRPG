using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChessBoardGridLock : MonoBehaviour
{
    [SerializeField] private ChessBoardGrid grid;

    private void OnMouseEnter()
    {
        GrabManager.Instance.LockGrabGOOnGrid(transform.position);
    }

    private void OnMouseExit()
    {
        GrabManager.Instance.UnLockGrabGO();
    }

    private void OnMouseDown()
    {
        grid.OnGrabPutDown();
    }
}