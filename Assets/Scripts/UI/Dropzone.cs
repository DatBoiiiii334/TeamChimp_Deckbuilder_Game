using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //public Draggable.cardType _CardType = Draggable.cardType.DAMAGE;
    public Card.cardType _CardType;
    public bool HasMana;

    public void OnPointerEnter(PointerEventData eventData){
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData){
        //Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        //Card d = GetComponent<Card>();

        if(d != null){
            if(_CardType == d._CardType) {
                if(HasMana = true){
                    d.parentToReturnTo = this.transform;
                }else{
                    return;
                }
            }
        }
    }
    
    ///NEW STUFF
    public Component[] kaarten;

    public void Update(){
        kaarten =  GetComponentsInChildren<CardTemplate>();

        foreach (CardTemplate kaart in kaarten){
            if(Player._instance.Mana < kaart.card.Mana){
                HasMana = false;
                Debug.Log("You are broke");
               }else if(Player._instance.Mana >= kaart.card.Mana){
                 HasMana = true;
                int type = (int)kaart.card.CardOfType;
                 switch(type){
                     case 0: //DAMAGE
                        if(kaart.card.AttackDamage > Enemy._instance.Shield){
                                int var;
                                var = kaart.card.AttackDamage -= Enemy._instance.Shield;
                                Enemy._instance.Shield = 0;
                                Enemy._instance.Health -= var;
                                Player._instance.Mana -= kaart.card.Mana;
                                Debug.Log("Milk him dry");
                                Destroy(kaart.gameObject); 

                            }else if(kaart.card.AttackDamage <= Enemy._instance.Shield){
                                Enemy._instance.Shield -= kaart.card.AttackDamage;
                                Player._instance.Mana -= kaart.card.Mana;
                                Debug.Log("Milk him dry... again");
                                Destroy(kaart.gameObject);
                            }
                        break;

                    case 1: // HEAL
                        Player._instance.Health += kaart.card.Health;
                        Player._instance.Mana -= kaart.card.Mana;
                        Destroy(kaart.gameObject);
                        break;

                    default: // Card has no grade
                        break;
                 }
             }
        }
    }
}
