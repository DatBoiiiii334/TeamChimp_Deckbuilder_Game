using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //public Draggable.cardType _CardType = Draggable.cardType.DAMAGE;
    public Card.cardType _CardType;
    public bool HasMana = true;
    public Component[] kaarten;
    public Transform playerCardDeck;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        //Card d = GetComponent<Card>();

        if (d != null)
        {
            if (_CardType == d._CardType)
            {
                if (d.TempMana <= Player._player.Mana)
                {
                    d.parentToReturnTo = this.transform;
                }
            }
        }
    }


    public void Update()
    {
        kaarten = GetComponentsInChildren<CardTemplate>();

        foreach (CardTemplate kaart in kaarten)
        {
            if (Player._player.Mana < kaart.card.Mana)
            {
                HasMana = false;
            }
            else if (Player._player.Mana >= kaart.card.Mana)
            {
                HasMana = true;

                int type = (int)kaart.card.CardOfType;
                switch (type)
                {
                    case 0: //DAMAGE
                        if (kaart.card.AttackDamage > Enemy._instance.Shield)
                        {
                            int var;
                            int kaartDamage = kaart.card.AttackDamage;
                            StartCoroutine(StartCombat("DoAttackAnim"));
                            //Do attack anim
                            var = kaartDamage -= Enemy._instance.Shield;
                            Enemy._instance.Shield = 0;
                            Enemy._instance.Health -= var;
                            Player._player.Mana -= kaart.card.Mana;
                            //Stop attack anim
                            Destroy(kaart.gameObject);
                        }
                        else if (kaart.card.AttackDamage <= Enemy._instance.Shield)
                        {
                            Destroy(kaart.gameObject);
                            StartCoroutine(StartCombat("DoAttackAnim"));
                            Enemy._instance.Shield -= kaart.card.AttackDamage;
                            Player._player.Mana -= kaart.card.Mana;
                        }
                        break;

                    case 1: // HEAL
                        Player._player.Health += kaart.card.Health;
                        Player._player.Shield += kaart.card.Shield;
                        Player._player.Mana -= kaart.card.Mana;
                        StartCoroutine(StartCombat("DoHealAnim"));
                        Destroy(kaart.gameObject);
                        break;

                    default: // Card has no grade
                        break;
                }
            }
        }
    }


    public IEnumerator StartCombat(string whatToDo)
    {
        Player._player.anim.SetBool(whatToDo, true);
        yield return new WaitForSeconds(0.1f);
        Player._player.anim.SetBool(whatToDo, false);
        StopAllCoroutines();
    }
}
