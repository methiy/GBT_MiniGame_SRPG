using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager
{
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            instance ??= new EventManager();
            return instance;
        }
    }
    private Dictionary<string, EventHandler> handlerDic = new Dictionary<string, EventHandler>();

    /// <summary>
    /// ���һ���¼��ļ�����
    /// </summary>
    /// <param name="eventName">�¼���</param>
    /// <param name="handler">�¼�������</param>
    public void AddListener(string eventName, EventHandler handler)
    {
        if (handlerDic.ContainsKey(eventName))
            handlerDic[eventName] += handler;
        else
            handlerDic.Add(eventName, handler);
    }

    /// <summary>
    /// �Ƴ�һ���¼��ļ�����
    /// </summary>
    /// <param name="eventName">�¼���</param>
    /// <param name="handler">�¼�������</param>
    public void RemoveListener(string eventName, EventHandler handler)
    {
        if (handlerDic.ContainsKey(eventName))
            handlerDic[eventName] -= handler;
    }

    /// <summary>
    /// �����¼����޲�����
    /// </summary>
    /// <param name="eventName">�¼���</param>
    /// <param name="sender">����Դ</param>
    public void TriggerEvent(string eventName, object sender)
    {
        if (handlerDic.ContainsKey(eventName))
            handlerDic[eventName]?.Invoke(sender, EventArgs.Empty);
    }

    /// <summary>
    /// �����¼����в�����
    /// </summary>
    /// <param name="eventName">�¼���</param>
    /// <param name="sender">����Դ</param>
    /// <param name="args">�¼�����</param>
    public void TriggerEvent(string eventName, object sender, EventArgs args)
    {
        if (handlerDic.ContainsKey(eventName))
            handlerDic[eventName]?.Invoke(sender, args);
    }

    /// <summary>
    /// ��������¼�
    /// </summary>
    public void Clear()
    {
        handlerDic.Clear();
    }
}
