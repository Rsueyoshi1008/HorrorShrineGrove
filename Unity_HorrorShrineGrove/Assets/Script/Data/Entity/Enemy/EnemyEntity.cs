using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data.Entity
{
    public class EnemyEntity
    {
        public int HP;
        public int ATK;
        public int DEF;
        public int Speed;
        public EnemyEntity(int hp, int atk, int def, int speed)
        {
            HP = hp;
            ATK = atk;
            DEF = def;
            Speed = speed;
        }
    }
}

