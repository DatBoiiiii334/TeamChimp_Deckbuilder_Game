using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardTemplate : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText, descriptionText, ManaValue, AttackValue, HealValue;
    //public card.cardType myCardType;
    public Card.cardType _card;
    public Image CharCardArt;
    private void Start()
    {
        nameText.text = card.Name;
        CharCardArt.sprite = card.Image;
        descriptionText.text = card.Description;
        ManaValue.text = card.Mana.ToString();
        AttackValue.text = card.AttackDamage.ToString();
        HealValue.text = card.Health.ToString();
        _card = card.CardOfType;
    }
}
