using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPropsTemplateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI hpMaxText;
    [SerializeField] private Image hpImage;

    private void Awake()
    {
        EventManager.Instance.AddListener(EventName.OnChangeGameFlowStateMachineEvent, ChangeGameFlow);
        EventManager.Instance.AddListener(EventName.OnPlayerHPChangedEvent, OnPlayerHPChanged);
        gameObject.SetActive(false);
    }
    private void Start()
    {
        
    }

    private void ChangeGameFlow(object obj,EventArgs e)
    {
        var args = e as OnChangeGameFlowStateMachineArgs;
        if(args.newState == GameFlowStateManager.Instance.moveCardState)
        {
            gameObject.SetActive(true);
            hpText.text = Player.Instance.maxHp.ToString();
            hpMaxText.text = Player.Instance.maxHp.ToString();
        }
    }
    private void OnPlayerHPChanged(object obj,EventArgs e)
    {
        hpText.text = Player.Instance.HP.ToString();
        hpImage.fillAmount = Player.Instance.HP / Player.Instance.maxHp;
    }
}
