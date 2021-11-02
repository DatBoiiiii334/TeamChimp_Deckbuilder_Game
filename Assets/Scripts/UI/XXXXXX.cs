using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XXXXXX : MonoBehaviour
{
    public static XXXXXX _instanceXXX;
    private Vector2 localMousePosition;

    public void awake()
    {
        if (_instanceXXX != null)
        {
            Destroy(gameObject);
        }
        _instanceXXX = this;
    }

    private void Start() {
        CheckKids();
    }

    void OnEnable()
    {
        EventManager.OnCardAction += CheckKids;
    }

    void OnDisable()
    {
        EventManager.OnCardAction -= CheckKids;
    }

    public void CheckKids()
    {
        
        int v;
        v = gameObject.transform.childCount;
        //if(gameObject.transform.childCount == 0){return;}
        foreach (Transform child in gameObject.transform)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(320f * v, 500f);
            gameObject.GetComponent<HorizontalLayoutGroup>().spacing = -100f * v;
        }
        //print(gameObject.name + " Child Amount: " +gameObject.transform.childCount);
        
        //localMousePosition = gameObject.GetComponent<RectTransform>().InverseTransformPoint(Input.mousePosition);
        //print(localMousePosition);
        // if (gameObject.GetComponent<RectTransform>().rect.Contains(localMousePosition))
        // {
        //     //if localMousePosition <= 300
        //     // print("It worky");

        // }
    }

    public void AddChildToListPos(int x)
    {
        int y;


    }

}
