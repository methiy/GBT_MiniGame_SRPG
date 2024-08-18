using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardTemplate : MonoBehaviour
{
    [SerializeField] private Button cardButton;
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private CardType cardType;
    [SerializeField] private List<Vector2> rangeList;
    [SerializeField] private string cardName;

    private void Start()
    {
        cardButton.onClick.AddListener(() =>
        {
            EventManager.Instance.TriggerEvent(EventName.CardSelectedEvent, this, new OnCardSelectedArgs
            {
                cardType = this.cardType,
                rangeList = this.rangeList
            });
        });
        cardNameText.text = this.cardName;
    }
}
