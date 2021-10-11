using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform cardDeckTransform;
    // public enum cardType {DAMAGE, MAGIC, ARMOR, BLEED}
    //public cardType CardOfType = cardType.DAMAGE;
    public Card.cardType _CardType;
    private CardTemplate myCardTemplate;
    public int TempMana;
    //public Card _card;
    //public cardType CardOfType = _card.CardOfType;

    public void Start()
    {
        myCardTemplate = GetComponent<CardTemplate>();
        _CardType = myCardTemplate._card;
        cardDeckTransform = this.transform.parent;
    }

    public void Update()
    {
        TempMana = myCardTemplate.card.Mana;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
