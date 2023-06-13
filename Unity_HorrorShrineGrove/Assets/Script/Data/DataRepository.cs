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
        public m500Entity m500 { get; }
        public AK47Entity ak47 { get; }
        public Plane007Entity plane007 { get; }

        public DataRepository()
        {
            player = InitializePlayer();
            enemy = InitializeEnemy();
            m500 = InitializeM500();
            ak47 = InitializeAK47();
            plane007 = InitializePlane007();
        }

        private PlayerEntity InitializePlayer()
        {
            var player = new PlayerEntity(10,2,10,0,30);
            return player;
        }
        private List<EnemyEntity> InitializeEnemy()
        {
            var list = new List<EnemyEntity>();
            list.Add(new EnemyEntity(10,0.1f,2,10,2,10,0));
            return list;
        }
        private m500Entity InitializeM500()
        {
            var list = new m500Entity(30);
            return list;
        }
        private AK47Entity InitializeAK47()
        {
            var ak = new AK47Entity(30);
            return ak;
        }
        private Plane007Entity InitializePlane007()
        {
            var plane = new Plane007Entity(25);
            return plane;
        }
        
    }

}
