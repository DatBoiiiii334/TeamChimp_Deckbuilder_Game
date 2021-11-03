using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardTemplate : MonoBehaviour
{
    public Card card;
    public delegate void AllSpellsFromCard();

    public AllSpellsFromCard myCardSpells;

    public TextMeshProUGUI nameText, descriptionText, ManaValue, AttackValue, HealValue;
    //public card.cardType myCardType;
    public Card.cardType _card;
    public Image CharCardArt;

    private void Start()
    {
        ScriptAdder();
        nameText.text = card.Name;
        CharCardArt.sprite = card.Image;
        descriptionText.text = card.Description;
        ManaValue.text = card.Mana.ToString();
        AttackValue.text = card.AttackDamage.ToString();
        HealValue.text = card.Health.ToString();
        _card = card.CardOfType;
    }

    public void ScriptAdder()
    {
        switch ((int)card.CardOfType)
        {
            case 0:
                RawDamage rd = gameObject.AddComponent<RawDamage>();
                break;

            case 1:
                HealPlayer hp = gameObject.AddComponent<HealPlayer>();
                break;

            case 2:
                VampiricStrike vp = gameObject.AddComponent<VampiricStrike>();
                break;

            default:
                break;
        }
    }

    public void ExecuteAction()
    {
        if (myCardSpells != null)
        {
            myCardSpells();
        }
    }
}
