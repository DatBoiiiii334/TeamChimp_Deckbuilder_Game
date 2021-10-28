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

    public void Update()
    {

        CheckKids();
        //mouseArt.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
    }

    public void CheckKids()
    {
        int v;
        v = gameObject.transform.childCount;
        foreach (Transform child in gameObject.transform)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(320f * v, 500f);
            gameObject.GetComponent<HorizontalLayoutGroup>().spacing = -100f * v;
        }

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
