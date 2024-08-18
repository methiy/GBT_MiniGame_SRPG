using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class CardTemplate : MonoBehaviour, IDragHandler, IEndDragHandler,IPointerEnterHandler,IPointerExitHandler
{

    [SerializeField]private int cardID;
    public void SetID(int index) => cardID = index;

    [SerializeField]private CardContainer cardContainer;

    [SerializeField] private Button cardButton;
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private CardType cardType;
    [SerializeField] private List<Vector2> rangeList;
    [SerializeField] private string cardName;

    private RectTransform rectTransform;
    [SerializeField]private Transform preParent;
    [SerializeField]private Transform tempParent;
    [SerializeField]private CanvasGroup canvasGroup;

    public float scaleUpFactor = 1.2f; // �Ŵ���
    public float scaleDuration = 0.2f; // ����ʱ��

    private Vector3 originalScale;

    private void Start()
    {
        cardButton.onClick.AddListener(() =>
        {
            MapManager.Instance.LockCells();
            EventManager.Instance.TriggerEvent(EventName.CardSelectedEvent, this, new OnCardSelectedArgs
            {
                cardType = this.cardType,
                rangeList = this.rangeList
            });
        });
        cardNameText.text = this.cardName;

        rectTransform = GetComponent<RectTransform>();

        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(originalScale * scaleUpFactor, scaleDuration).SetEase(Ease.OutBack);
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(originalScale, scaleDuration).SetEase(Ease.InBack);
    }

    public void OnDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false; // �����϶���������UIԪ��
        transform.SetParent(tempParent);
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // �ָ�UI����
        cardContainer.SetCardTempParent(cardID, tempParent);
        cardContainer.SetCardPreParent(preParent);
    }

}


