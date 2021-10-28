using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverScale_Size : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 newSize = new Vector2(420f, 560f);
    private Vector3 oldSize = new Vector2(300f, 400f);


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //gameObject.transform.localScale = newSize;
            gameObject.GetComponent<RectTransform>().sizeDelta = newSize;
            //GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0f,0f,0f); 
        }

        //Que the hover over sound
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //gameObject.transform.localScale = oldSize;
        gameObject.GetComponent<RectTransform>().sizeDelta = oldSize;
        //GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0f,0f,5f); 
    }
}
