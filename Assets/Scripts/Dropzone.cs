using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Draggable.cardType _CardType = Draggable.cardType.DAMAGE;

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if(d != null){
            //if(_CardType == d._CardType) {
                d.parentToReturnTo = this.transform;
            //}
        }
    }
}
