using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCard", menuName = "CreateNewCard", order = 1)]
public class EnemyCore : ScriptableObject
{
    [SerializeField]
    private int ID;
    [SerializeField]
    private string _name, _description;
    public Sprite Image;
    [SerializeField]
    private int _mana, _attackDamage, _health;
    [SerializeField]
    private cardType _cardOfType;

    public enum cardType { DAMAGE, HEALING }
    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Mana { get { return _mana; } }
    public int AttackDamage { get { return _attackDamage; } }
    public int Health { get { return _health; } }
    public cardType CardOfType { get { return _cardOfType; } }
}