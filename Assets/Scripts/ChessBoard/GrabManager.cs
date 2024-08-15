using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    public static GrabManager Instance { get; private set; }

    [SerializeField] private GameObject grabGO;
    private bool isLock = false;
    private Camera camera = new Camera();

    public void Awake()
    {
        Instance = this;
        camera = Camera.main;
    }

    public void Update()
    {
        if (!this.grabGO || isLock)
        {
            return;
        }
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            var high = hit.collider.bounds.size.y;
            this.grabGO.gameObject.transform.position = new Vector3(hit.point.x,hit.collider.transform.position.y+high,hit.point.z);
        }
    }

    // TODO:转换成状态机更换当前需要抓取的mesh
    public void Start()
    {
        grabGO.SetActive(true);
        grabGO.GetComponent<MeshFilter>().mesh = GameObject.Find("Player").GetComponent<MeshFilter>().mesh;
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
    public void OnGrabGOPutDown()
    {
        this.grabGO.SetActive(false);
    }
}