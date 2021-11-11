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
    //public Card.cardType _card;
    public Image CharCardArt;

    private void Start()
    {
        ScriptAdder();
        nameText.text = card.Name;
        CharCardArt.sprite = card.Image;
        descriptionText.text = card.Description;
        ManaValue.text = card.Mana.ToString();

        //AttackValue.text = card.AttackDamage.ToString();
        //HealValue.text = card.Health.ToString();
       // _card = card.CardOfType;
    }

    public void ScriptAdder()
    {
        foreach (BaseEffect ability in card.Effects)
        {
            if (card.Effects.Count == 0) { return; }
            ability.template = gameObject.GetComponent<CardTemplate>();
            myCardSpells += ability.ApplyEffect;
        }
    }

    public void ExecuteAction()
    {
        if (myCardSpells != null)
        {
            myCardSpells();
            Player._player.Mana -= card.Mana;
            Player._player.UpdatePlayerUI();
            EnemyBody._instanceEnemyBody.UpdateEnemyUI();
        }
    }
}
