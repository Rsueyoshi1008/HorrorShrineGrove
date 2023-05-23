using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Script.Player
{
    public class PlayerUseCase
    {
        
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
        
    }

}
