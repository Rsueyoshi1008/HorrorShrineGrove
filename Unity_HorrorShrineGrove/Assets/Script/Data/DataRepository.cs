using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Entity;
namespace Data.Repository
{
    public class DataRepository
    {
        public List<PlayerEntity> player{ get; }
        public List<EnemyEntity> enemy{ get; }

        public DataRepository()
        {
            player = InitializePlayer();
            enemy = InitializeEnemy();
        }

        private List<PlayerEntity> InitializePlayer()
        {
            var list = new List<PlayerEntity>();
            list.Add(new PlayerEntity(10,2,10));
            return list;
        }
        private List<EnemyEntity> InitializeEnemy()
        {
            var list = new List<EnemyEntity>();
            list.Add(new EnemyEntity(10,1,2,5));
            return list;
        }
        
    }

}
