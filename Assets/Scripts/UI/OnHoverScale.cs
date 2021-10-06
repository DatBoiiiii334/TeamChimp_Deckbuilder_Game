using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 newSize = new Vector3(1.5f, 1.5f, 0f);
    private Vector3 oldSize = new Vector3(1f, 1f, 0f);
    private bool selected;
    public int v = 0;


    public void OnSelect()
    {
        // if(v >= 1) {
        //     OnDeSelect();
        // }
        // else {
        //     gameObject.transform.localScale = newSize;
        //     selected = true;
        //     v += 1;
        // }
    }

    public void OnDeSelect()
    {
        gameObject.transform.localScale = oldSize;
        selected = false;
        v = 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject != null) {
            gameObject.transform.localScale = newSize;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected == false) {
            gameObject.transform.localScale = oldSize;
        }
    }
}
