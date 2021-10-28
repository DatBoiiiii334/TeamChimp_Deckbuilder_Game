using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Card", menuName = "Create New Card", order = 1)]
public class Card : ScriptableObject
{
    [SerializeField]
    private int ID;
    [SerializeField]
    private string _name, _description;
    [SerializeField]
    public Sprite Image;
    [SerializeField]
    private int _mana, _attackDamage, _health, _shield;
    [SerializeField]
    private cardType _cardOfType;
    [SerializeField]
    private bool _applyToPlayer;

    public enum cardType { DAMAGE, HEALING, VAMPIRIC }
    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Mana { get { return _mana; } }
    public int AttackDamage { get { return _attackDamage; } }
    public int Health { get { return _health; } }
    public int Shield { get { return _shield; } }
    public cardType CardOfType { get { return _cardOfType; } }
    public bool ApplyToPlayer { get { return _applyToPlayer; } }
}
