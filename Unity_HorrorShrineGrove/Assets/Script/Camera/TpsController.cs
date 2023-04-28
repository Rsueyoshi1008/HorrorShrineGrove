using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsController : MonoBehaviour
{
    //カメラ
    [SerializeField] private Camera mainCamera;
    //カメラの軸になるオブジェクト
    [SerializeField] private Transform target;

    private Vector3 distance; //カメラの初期位置とターゲットの位置の差分
    
    private float turnSpeed = 3.0f;   // カメラの回転速度
    private float pitchMin = -60.0f; //カメラの最小角
    private float pitchMax = 60.0f; //カメラの最大角
    private float horizontalityAngle = 0.0f;  //水平のカメラ角度
    private float verticalAngle = 0.0f; //垂直のカメラ角度
    // Start is called before the first frame update
    void Start()
    {
        //カメラとプレイヤーとの距離を計算
        float Distance = transform.position.z - target.position.z;
        distance = new Vector3(0.0f,6f,Distance );
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //マウスのX座標の移動量を取得
        float horizontal = Input.GetAxis("Mouse X") * turnSpeed;

        //マウスのY座標の移動量を取得
        float vertical = Input.GetAxis("Mouse Y") * turnSpeed;

        horizontalityAngle += horizontal;
        Quaternion horizontalityRotation = Quaternion.Euler(-60f, horizontalityAngle, 0f);
       
        
        verticalAngle += vertical;
        verticalAngle = Mathf.Clamp(verticalAngle, pitchMin, pitchMax);
        Quaternion verticalRotation = Quaternion.Euler(-verticalAngle, 0f, 0f);

        Vector3 position = target.position + horizontalityRotation * verticalRotation * distance;

        // カメラの位置を更新
        transform.position = position;
        // カメラがターゲットを注目する
        transform.LookAt(target);
    }
}
