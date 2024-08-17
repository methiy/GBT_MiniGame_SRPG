using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArea : MonoBehaviour
{
    [SerializeField] private Button collectionButton;
    [SerializeField] private Button skipButton;
    [SerializeField] private Transform cardContainer;
    [SerializeField] private List<Transform> moveCardGroup;
    [SerializeField] private List<Transform> magicCardGroup;

    private void Start()
    {
        EventManager.Instance.AddListener(EventName.DrawCardEvent, OnDrawCardEvent);
        EventManager.Instance.AddListener(EventName.HideCardAreaEvent, (object obj, EventArgs e) =>
        {
            gameObject.SetActive(false);
        });
        collectionButton.onClick.AddListener(OnCollectionButtonClicked);
        skipButton.onClick.AddListener(OnSkipButtonClicked);
        gameObject.SetActive(false);
    }

    private void OnCollectionButtonClicked()
    {
        // 检测集气多少;
        PlayerProps.Instance.AddPower(4);
        if (PlayerProps.Instance.SubStep(1) > 0) 
        {
            GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.magicCardState);
        }
        else
        {
            GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.enemyState);
        }
    }
    private void OnSkipButtonClicked()
    {
        GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.moveCardState);
    }
    private void OnDrawCardEvent(object sender,EventArgs e)
    {
        gameObject.SetActive(true);
        OnDrawCardArgs args = e as OnDrawCardArgs;
        if (args == null)
        {
            return;
        }
        switch (args.cardType)
        {
            case CardType.MoveCard:
                ShowUIElement(moveCardGroup);
                HideUIElement(magicCardGroup);
                break;
            case CardType.MagicCard:
                ShowUIElement(magicCardGroup);
                HideUIElement(moveCardGroup);
                break;
        }
    }

    private void ShowUIElement(List<Transform> elements)
    {
        foreach (Transform element in elements)
        {
            element.gameObject.SetActive(true);
        }
    }
    private void HideUIElement(List<Transform> elements)
    {
        foreach(Transform element in elements)
        {
            element.gameObject.SetActive(false);
        }
    }
}
