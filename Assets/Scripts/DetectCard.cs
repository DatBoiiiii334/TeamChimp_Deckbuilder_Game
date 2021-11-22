using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Draggable>()){
            print("Detected");
            CardSystemManager._instance.NExtCard();
        }
    }
}
