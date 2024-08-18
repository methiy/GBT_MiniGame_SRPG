using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform moveTrans;
    [SerializeField] private Camera cameraComponent;
    private Transform originTrans;
    private void Start()
    {
        originTrans = transform;
    }

    private void MoveCamera(object obj,EventArgs e)
    {
        //cameraComponent.transform = moveTrans;
    }
}
