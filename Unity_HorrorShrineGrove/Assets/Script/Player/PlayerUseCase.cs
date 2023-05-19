using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Script.Player
{
    public class PlayerUseCase : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        
        public void Move(Vector3 movement, float moveSpeed)
        {

            //キャラの移動をする
            //_player.Translate(movement * moveSpeed * Time.deltaTime);
            
            
        }
        
        public void Test(Transform test)
        {
            Debug.Log(test.position.y);
        }
    }

}
