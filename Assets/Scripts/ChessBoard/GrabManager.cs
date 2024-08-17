using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    public static GrabManager Instance { get; private set; }

    [SerializeField] private GameObject grabGO;
    private GameObject currentHandleGO;
    private bool isLock = false;
    private Camera sceneCamera;

    private void Awake()
    {
        Instance = this;
        this.sceneCamera = Camera.main;
    }

    private void Start()
    {
        EventManager.Instance.AddListener(EventName.OnGrabObjectPutDownEvent, OnGrabGOPutDown);
    }
    private void Update()
    {
        if (!currentHandleGO || isLock)
        {
            return;
        }
        Ray ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            grabGO.gameObject.transform.position = hit.point;
        }
    }

    public void UpdateGrabGO(GameObject newGrabGO)
    {
        currentHandleGO = newGrabGO;
        grabGO.GetComponent<MeshFilter>().mesh = newGrabGO.GetComponent<MeshFilter>().mesh;
        grabGO.SetActive(true);
    }

    // 固定当前抓取的物体到某一格上
    public void LockGrabGOOnGrid(Vector3 putPosition)
    {
        this.isLock = true;
        this.grabGO.transform.position = putPosition;
    }

    // 解锁
    public void UnLockGrabGO()
    {
        this.isLock = false;
    }

    public GameObject GetHandleGO()
    {
        return this.currentHandleGO;
    }

    // 当在某一格放下时隐藏GrabGO
    private void OnGrabGOPutDown(object sender, EventArgs e)
    {
        currentHandleGO = null;
        grabGO.SetActive(false);
    }
}