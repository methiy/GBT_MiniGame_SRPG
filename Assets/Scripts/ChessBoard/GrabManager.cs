using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    public static GrabManager Instance { get; private set; }

    [SerializeField] private GameObject grabGO;
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
        if (!this.grabGO || isLock)
        {
            return;
        }
        Ray ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            var high = hit.collider.bounds.size.y;
            this.grabGO.gameObject.transform.position = new Vector3(hit.point.x,hit.collider.transform.position.y+high,hit.point.z);
        }
    }

    public void UpdateGrabMesh(GameObject newGrabGO)
    {
        grabGO.SetActive(true);
        grabGO.GetComponent<MeshFilter>().mesh = newGrabGO.GetComponent<MeshFilter>().mesh;
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
    
    // 当在某一格放下时隐藏GrabGO
    public void OnGrabGOPutDown(object sender, EventArgs e)
    {
        this.grabGO.SetActive(false);
    }
}