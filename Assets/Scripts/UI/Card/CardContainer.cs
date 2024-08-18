using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardContainer : MonoBehaviour
{
    private List<CardTemplate>  cards = new List<CardTemplate>();

    private Transform drawPosition; // 抽牌位置
    private Transform discardPosition; // 弃牌位置
    private Transform cardPilePosition;
    [SerializeField]private GameObject cardPrefab;
    public List<CardTemplate> moveCards;
    public List<CardTemplate> magicCards;
    private List<CardTemplate> myCards = new List<CardTemplate>();

    private void Start()
    {
        drawPosition = GameObject.Find("DrawCardPosition")?.transform;
        discardPosition = GameObject.Find("DiscordCardPosition")?.transform;
        cardPilePosition = GameObject.Find("CardContainer")?.transform;
    }
    public void DrawCardWithType(CardType cardType)
    {
        foreach (var card in myCards)
        {
            Destroy(card.gameObject);
        }
        myCards.Clear();
        List<CardTemplate> cardList;

        if(cardType == CardType.MoveCard)
        {
            cardList = moveCards;
        }
        else
        {
            cardList = magicCards;
        }

        for(int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, cardList.Count);
            CardTemplate card = Instantiate(cardList[index]);
            card.transform.SetParent(transform);
            myCards.Add(card);
        }
        StartCoroutine(MoveToPosition(new Vector3(0, 183, 0), new Vector3(980, 183, 0)));
    }
    public void Init(){
        //drawPosition = GameObject.Find("DrawCardPosition")?.transform;
        //discardPosition = GameObject.Find("DiscordCardPosition")?.transform;
        //cardPilePosition = GameObject.Find("CardContainer")?.transform;
        DrawCard();
        InitCardList();
    }
    public void Uninit(){
        foreach (var card in cards)
        {
            Destroy(card.gameObject);
        }
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
        UpdateCardsID();
    }

    public void SetCardPreParent(Transform parent){
        for (int i = 0; i < cards.Count; i++){
            cards[i].transform.SetParent(parent);
        }
        InitCardList();
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

    public float animationDuration = 0.5f; // 动画持续时间
    private const int MAX_CARDAMOUNT = 5;
    public float baseDuration = 5f;
    public void DrawCard()
    {
        List<Transform> list = new List<Transform>();
        for (int i = 0; i < MAX_CARDAMOUNT; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab, drawPosition.position, Quaternion.identity);
            Transform card = cardObject.transform;
            list.Add(card);
            card.SetParent(transform);
            card.gameObject.SetActive(false);
        }
        for (int i = 0; i < MAX_CARDAMOUNT; i++)
        {
            Transform card = list[i];
            card.gameObject.SetActive(true);
        }
        StartCoroutine(MoveToPosition(new Vector3(0,183,0),new Vector3(980,183,0)));
    }

    public void DiscordCard()
    {
        StartCoroutine(MoveToPosition(new Vector3(980,183,0),new Vector3(2200,183,0)));

    }

    public float moveDuration = 0.001f; // 移动时间

    private float elapsedTime = 0f; // 已经经过的时间

    private IEnumerator MoveToPosition(Vector3 startPosition,Vector3 endPosition)
    {
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            // 计算插值系数 t
            float t = elapsedTime / moveDuration;

            // 使用 Lerp 函数计算当前位置
            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            // 更新经过的时间
            elapsedTime += Time.deltaTime;

            // 等待下一帧
            yield return null;
        }

        // 确保最终位置精确设置到目标位置
        transform.position = endPosition;
        yield return new WaitForSeconds(1f);
    }

    

}
