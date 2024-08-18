using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
    MoveCard,
    MagicCard
}
public class CardArea : MonoBehaviour
{
    [SerializeField] private Button skipButton;
    [SerializeField] private Transform cardContainer;
    [SerializeField] private List<Transform> moveCardGroup;
    [SerializeField] private List<Transform> magicCardGroup;
    private CardType cardType;
    private bool bCanCollection = true;

    private void Start()
    {
        EventManager.Instance.AddListener(EventName.OnChangeGameFlowStateMachineEvent, OnChangeGameFlowStateMachine);
        skipButton.onClick.AddListener(OnSkipButtonClicked);
        gameObject.SetActive(false);
    }

    private void OnChangeGameFlowStateMachine(object obj, EventArgs args)
    {
        var e = args as OnChangeGameFlowStateMachineArgs;
        if ((e.oldState == GameFlowStateManager.Instance.beginState || e.oldState == GameFlowStateManager.Instance.enemyState) && e.newState == GameFlowStateManager.Instance.moveCardState)
        {
            gameObject.SetActive(true);
            cardType = CardType.MoveCard;
            bCanCollection = true;
        }
        else if (e.newState == GameFlowStateManager.Instance.magicCardState)
        {
            cardType = CardType.MagicCard;
        }
        else if (e.newState == GameFlowStateManager.Instance.moveCardState)
        {
            cardType = CardType.MoveCard;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void OnSkipButtonClicked()
    {
        switch (cardType)
        {
            case CardType.MoveCard:
                if (bCanCollection)
                {
                    OnCollection();
                    bCanCollection = false;
                }
                if (PlayerProps.Instance.SubStep(1) > 0)
                {
                    GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.magicCardState);
                }
                else
                {
                    GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.enemyState);
                }
                break;
            case CardType.MagicCard:
                GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.moveCardState);
                break;
        }
    }

    private void OnCollection()
    {
        // 检测集气多少;
        print("集气");
        PlayerProps.Instance.AddPower();
    }
}
