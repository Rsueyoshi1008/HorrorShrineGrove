using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Entity;
namespace Data.Repository
{
    public class DataRepository
    {
        public PlayerEntity player{ get; }
        public List<EnemyEntity> enemy{ get; }
        public M500Entity m500 { get; }

        public DataRepository()
        {
            player = InitializePlayer();
            enemy = InitializeEnemy();
            m500 = InitializeM500();
        }

        private PlayerEntity InitializePlayer()
        {
            var player = new PlayerEntity(10,2,10,0,30);
            return player;
        }
        private List<EnemyEntity> InitializeEnemy()
        {
            var list = new List<EnemyEntity>();
            list.Add(new EnemyEntity(10,0.1f,2,10,2));
            return list;
        }
        private M500Entity InitializeM500()
        {
            var m500 = new M500Entity(30);
            return m500;
        }
        
    }

}
