using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.AddListener(EventName.OnGrabObjectPutDownEvent, (object sender, EventArgs args) =>
        {
            OnGrabObjectPutDownArgs data = args as OnGrabObjectPutDownArgs;
            this.transform.position = data.putPosition;
        });
    }
}
