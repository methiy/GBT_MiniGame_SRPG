using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContainer : MonoBehaviour
{
    private List<CardTemplate>  cards = new List<CardTemplate>();

    private void Start()
    {
        InitCardList();
    }

    private void InitCardList(){
        cards.Clear();
        foreach (Transform child in transform)
        {
            CardTemplate card = child.GetComponent<CardTemplate>();
            if (card != null)
            {
                cards.Add(card);
            }
        }
    }

    public void SetCardPreParent(Transform parent){
        for (int i = 0; i < cards.Count; i++){
            cards[i].transform.SetParent(parent);
        }
        InitCardList();
        UpdateCardsID();
    }
    public void SetCardTempParent(int index,Transform parent){
        for (int i = index; i < cards.Count; i++){
            cards[i].transform.SetParent(parent);
        }
    }


    public void UpdateCardsID(){
        int index = 0;
        foreach (var card in cards)
        {
            SetCardsID(card,index);
            index++;
        }
    }
    public void SetCardsID(CardTemplate card, int index){
        card.SetID(index);
    }

}
