using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Humanoid
{
    public static Player _instance;
    public int Mana;
    public TextMeshProUGUI ManaField;

    public void Update()
    {
        NameField.text = Name;
        HealthField.text = Health.ToString();
        ShieldField.text = Shield.ToString();
        ManaField.text = Mana.ToString();
    }

    private void Awake(){

        if(_instance != null){
            Destroy(gameObject);
        }

        _instance = this;

    }
}
