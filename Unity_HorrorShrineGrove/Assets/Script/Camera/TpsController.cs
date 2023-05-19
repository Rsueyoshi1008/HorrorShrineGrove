using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TpsController : MonoBehaviour
{
    //カメラ
    [SerializeField] private Camera mainCamera;
    //カメラの軸になるオブジェクト
    [SerializeField] private Transform target;

    public UnityAction <Vector3,float> EventPlayer;

    private Vector3 distance; //カメラの初期位置とターゲットの位置の差分
    
    private float turnSpeed = 3.0f;   // カメラの回転速度

    private float rotationX = 0.0f; 

    private float moveSpeed = 5f; 

    private bool invertY = true;//左右移動を反転させるかどうか


    // Start is called before the first frame update
    void Start()
    {
        //カメラとプレイヤーとの距離を計算
        float Distance = transform.position.z - target.position.z;
        distance = new Vector3(0.0f,6f,Distance );
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //マウスのX座標の移動量を取得
        float horizontal = Input.GetAxis("Mouse X") * turnSpeed;

        //マウスのY座標の移動量を取得
        float vertical = Input.GetAxis("Mouse Y") * turnSpeed;

        //水平の入力取得
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        //垂直の入力を取得
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (!invertY)
        {
            horizontal *= -1;
        }

        // カメラの水平方向の回転を適用する
        transform.localRotation *= Quaternion.Euler(0, horizontal, 0);

        // 垂直方向の回転を計算する
        rotationX -= vertical;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        Vector3 movement = transform.forward * verticalInput + transform.right * horizontalInput;
        //移動ベクトルの正規化
        movement.Normalize();

        //カメラの高さを保持
        float originalCameraHeight = transform.position.y;
        //キャラの移動をする
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        //カメラの高さを元に戻す
        transform.position = new Vector3(transform.position.x, originalCameraHeight, transform.position.z);

        //イベントPlayer
        EventPlayer?.Invoke(movement,moveSpeed);

        // カメラの垂直方向の回転を適用する
        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0);
        
    }
}
