using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Humanoid
{
    public static Player _player;
    public int Mana;
    public TextMeshProUGUI ManaField;

    public Animator anim;

    public void Start(){
        anim = this.gameObject.GetComponent<Animator>();
        anim.Play("DEV_Idle");
    }

    public void Update()
    {
        //  if (anim.isPlaying)
        // {
        //     return;
        // }

        NameField.text = Name;
        HealthField.text = Health.ToString();
        ShieldField.text = Shield.ToString();
        ManaField.text = Mana.ToString();
    }

    private void Awake()
    {
        if (_player != null)
        {
            Destroy(gameObject);
        }
        _player = this;

    }
}
