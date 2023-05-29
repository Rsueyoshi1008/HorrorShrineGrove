using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data.Entity
{
    public class EnemyEntity
    {
        public int HP;
        public float ATK;
        public int DEF;
        public int Speed;
        public int PlayerDamage;
        public EnemyEntity(int hp, float atk, int def, int speed, int playerDamage)
        {
            HP = hp;
            ATK = atk;
            DEF = def;
            Speed = speed;
            PlayerDamage = playerDamage;
        }
    }
}

