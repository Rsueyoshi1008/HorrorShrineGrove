using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Entity;
namespace Data.Repository
{
    public class DataRepository
    {
        public List<PlayerEntity> player{ get; }

        public DataRepository()
        {
            player = InitializePlayer();
        }

        private List<PlayerEntity> InitializePlayer()
        {
            var list = new List<PlayerEntity>();
            list.Add(new PlayerEntity(10,2));
            return list;
        }
        
    }

}
