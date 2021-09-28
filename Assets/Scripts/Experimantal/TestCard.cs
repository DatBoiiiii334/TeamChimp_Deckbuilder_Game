using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayCard
{
    public abstract class TestCard : MonoBehaviour
    {
        public string Id;
        public CardType type;
        public string Name;
        public string Description;
        public int grade;
        public Sprite Image;


        public enum CardType {
            Damage, Magic, Armor, Heal
        }

    }

}
