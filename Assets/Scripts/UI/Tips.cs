using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tips : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private string BeginPlayText;
    [SerializeField] private string MoveText;
    [SerializeField] private string MagicText;
    [SerializeField] private string EnemyText;
    private void Awake()
    {
        EventManager.Instance.AddListener(EventName.OnChangeGameFlowStateMachineEvent, OnChangeGameFlowState);
    }
    private void Start()
    {
        
    }

    private void OnChangeGameFlowState(object obj,EventArgs e)
    {
        OnChangeGameFlowStateMachineArgs args = e as OnChangeGameFlowStateMachineArgs;
        switch (args.newState)
        {
            case BeginPlayState:
                messageText.text = BeginPlayText;
                break;
            case MoveCardState:
                messageText.text = MoveText;
                break;
            case MagicCardState:
                messageText.text = MagicText;
                break;
            case EnemyState:
                messageText.text = EnemyText;
                break;
            default:
                gameObject.SetActive(false);
                break;
        }
    }
}
