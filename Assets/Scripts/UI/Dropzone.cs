using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData) { }

    public void OnPointerExit(PointerEventData eventData) { }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable DroppedCardDragComponent = eventData.pointerDrag.GetComponent<Draggable>();
        CardTemplate DroppedCard = eventData.pointerDrag.GetComponent<CardTemplate>();

        if (DroppedCard == null) { return; }
        if (DroppedCard.card.Mana > Player._player.Mana) { return; }

        DroppedCardDragComponent.parentToReturnTo = this.transform;
        CommidCardAction(DroppedCard);
    }

    public void CommidCardAction(CardTemplate _droppedCard)
    {
        _droppedCard.ExecuteAction();
        Destroy(_droppedCard.gameObject);
    }
}
