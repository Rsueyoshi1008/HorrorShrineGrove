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

        public PlayerUseCase(DataRepository Repository)
        {
            _repository = Repository;
            _model = new PlayerModel();
        }

        public void SynModel()
        {
            var player = _repository.player[0];

            _model.HP = player.HP;
            _model.ATK = player.ATK;
            
            ChangeModel?.Invoke(_model);
        }
        public void Move(float horizontalInput , float verticalInput, float movespeed,Transform moveObject)
        {
        //    //ベクトルに変換する
        //     Vector3 movement = new Vector3(horizontalInput,2.0f,verticalInput);

        //     //移動ベクトルを正規化する
        //     movement = movement.normalized;

        //     //キャラの移動をする
        //     moveObject.position = movement * movespeed * Time.deltaTime;
        //     Debug.Log("Move");
            
        }
        //敵から攻撃を受けたときの関数
        public void Damage(int damage)
        {
            Debug.Log(_model.HP);
            _model.HP -= damage;
            Debug.Log("HP" + _model.HP);
        }
        
    }

}
