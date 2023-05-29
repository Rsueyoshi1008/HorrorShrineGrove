using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemys.Model
{
    public class EnemyModel
    {
        public int HP;
        public int ATK;
        public int DEF;
        public int Speed;
        public int PlayerDamage;
        public EnemyModel()
        {
            HP = 0;
            ATK = 0;
            DEF = 0;
            Speed = 0;
            PlayerDamage = 0;
        }
    }
}

