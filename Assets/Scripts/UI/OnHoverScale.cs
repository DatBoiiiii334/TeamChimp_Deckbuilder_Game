using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 newSize = new Vector3(1.5f, 1.5f, 0f);
    private Vector3 oldSize = new Vector3(1f, 1f, 0f);

    //FOR WHEN INCREAING HIGHT AND WIDTH
    //private Vector3 newSize = new Vector2(420f, 560f);
    //private Vector3 oldSize = new Vector2(300f, 400f);
    private bool selected;
    public int v = 0;


    public void OnSelect()
    {
    }

    public void OnDeSelect()
    {
        gameObject.transform.localScale = oldSize;
        selected = false;
        v = 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            gameObject.transform.localScale = newSize;
            gameObject.GetComponent<RectTransform>().sizeDelta = newSize;
            //GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0f,0f,0f); 
        }

        //Que the hover over sound
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected == false)
        {
            gameObject.transform.localScale = oldSize;
            gameObject.GetComponent<RectTransform>().sizeDelta = oldSize;
            //GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0f,0f,5f); 
        }
    }
}
