using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
    MoveCard,
    MagicCard,
}
public class CardArea : MonoBehaviour
{
    public AudioClip clip;
    [SerializeField] private Button skipButton;
    [SerializeField] private CardContainer cardContainer;
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
            //cardContainer.GetComponent<CardContainer>().Init();
            cardType = CardType.MoveCard;
            cardContainer.DrawCardWithType(cardType);
            bCanCollection = true;
        }
        else if (e.newState == GameFlowStateManager.Instance.magicCardState)
        {
            cardType = CardType.MagicCard;
            cardContainer.DrawCardWithType(cardType);
        }
        else if (e.newState == GameFlowStateManager.Instance.moveCardState)
        {
            cardType = CardType.MoveCard;
            cardContainer.DrawCardWithType(cardType);
        }
        else
        {
            gameObject.SetActive(false);
            //cardContainer.GetComponent<CardContainer>().DiscordCard();
            //cardContainer.GetComponent<CardContainer>().Uninit();
        }
    }
    private void OnSkipButtonClicked()
    {
        ClipManager.Instance.PlayClip(clip);
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
        // ��⼯������;
        print("����");
        PlayerProps.Instance.AddPower();
    }
}
