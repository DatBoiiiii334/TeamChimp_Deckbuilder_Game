using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCard", menuName = "CreateNewCard", order=1)]
public class Card : ScriptableObject {

    public int ID, amount;
    public string grade;
    public new string name;
    public string Description;
    public Sprite Image;
    public int Mana, AttackDamage, Health, statusEffect;
    
    public enum cardType {DAMAGE, MAGIC, ARMOR, BLEED}
    public cardType CardOfType = cardType.DAMAGE;
}
