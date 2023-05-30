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
        public int EnemyKill;
        public int Bullet;

        public PlayerEntity(int hp, int atk, int speed, int enemyKill, int bullet)
        {
            HP = hp;
            ATK = atk;
            Speed = speed;
            EnemyKill = enemyKill;
            Bullet = bullet;
        }
    }
}

    

