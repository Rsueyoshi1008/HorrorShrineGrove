using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data.Entity
{
    public class PlayerEntity
    {
        public int HP;
        public int ATK;
        public int Speed;

        public PlayerEntity(int hp, int atk, int speed)
        {
            HP = hp;
            ATK = atk;
            Speed = speed;
        }
    }
}

    

