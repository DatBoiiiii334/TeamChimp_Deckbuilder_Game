using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCard", menuName = "CreateNewCard", order=1)]
public class Card : ScriptableObject {

    public int ID, amount;
    public string Grade, Name, Description;
    public Sprite Image;
    public int Mana, AttackDamage, Health, statusEffect;
    
    public enum cardType {DAMAGE, HEALING}
    public cardType CardOfType;

}
