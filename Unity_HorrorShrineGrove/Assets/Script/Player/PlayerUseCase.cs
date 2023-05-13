using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Player
{
    public class PlayerUseCase : MonoBehaviour
    {
        private float MoveSpeed = 5f;

        [SerializeField] private Rigidbody rb;
        void Update()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Move(horizontalInput,verticalInput);
        }
        public void Move(float horizontalInput , float verticalInput)
        {
           //ベクトルに変換する
            Vector3 movement = new Vector3(horizontalInput,1.0f,verticalInput);

            //移動ベクトルを正規化する
            movement = movement.normalized;

            //キャラの移動をする
            transform.Translate(movement * MoveSpeed * Time.deltaTime);
            //Debug.Log(movement);
        }
        
    }

}
