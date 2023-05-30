using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InGame.Player.Model;
using Data.Repository;
namespace Script.Player
{
    public class PlayerUseCase
    {
        private PlayerModel _model; 
        private DataRepository _repository;

        public UnityAction<PlayerModel> ChangeModel;
        

        private Transform Player;

        public PlayerUseCase(DataRepository Repository)
        {
            _repository = Repository;
            _model = new PlayerModel();
        }

        public void GetTarget(Transform target)
        {
            Player = target;
        }

        public void SynModel()
        {
            var player = _repository.player;

            _model.HP = player.HP;
            _model.ATK = player.ATK;
            _model.Speed = player.Speed;
            _model.Bullet = player.Bullet;
            
            ChangeModel?.Invoke(_model);
        }
        public void Move(Vector3 movement)
        {
            //キャラの移動をする
            Player.Translate(movement * _model.Speed * Time.deltaTime,Space.World);
            
        }
        
        
    }

}
