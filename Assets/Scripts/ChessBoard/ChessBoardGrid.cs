using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardGrid : MonoBehaviour
{
    [SerializeField] private ChessBoardGridLock lockComponent;
    private GameObject lockGO;

    private void Awake()
    {
        EventManager.Instance.AddListener(EventName.OnGrabObjectBeginEvent, OnGrabBegin);
        EventManager.Instance.AddListener(EventName.OnGrabObjectEndEvent, OnGrabEnd);
    }

    private void OnGrabBegin(object sender, EventArgs e)
    {
        // 判断是否符合放置位置的条件
        if (lockGO == null)
        {
            lockComponent.gameObject.SetActive(true);
        }
    }

    private void OnGrabEnd(object sender, EventArgs e)
    {
        lockComponent.gameObject.SetActive(false);
    }

    public void OnGrabPutDown()
    {
        lockGO = GrabManager.Instance.GetHandleGO();
        EventManager.Instance.TriggerEvent(EventName.OnGrabObjectPutDownEvent, this, new OnGrabObjectPutDownArgs
        {
            putPosition = lockComponent.transform.position,
        });
    }

    public ChessBoardGrid SetLockGO(GameObject go)
    {
        lockGO = go;
        go.transform.position = lockComponent.transform.position;
        return this;
    }

    public void ClearLockGO()
    {
        lockGO = null;
    }
}
