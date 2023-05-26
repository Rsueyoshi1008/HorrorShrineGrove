using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TpsController : MonoBehaviour
{
    public UnityAction<Vector3> EventMove;
    
    private float turnSpeed = 3.0f;   // カメラの回転速度

    private float rotationX;
    private bool invertY  = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //マウスのX座標の移動量を取得
        float horizontal = Input.GetAxis("Mouse X") * turnSpeed;

        //マウスのY座標の移動量を取得
        float vertical = Input.GetAxis("Mouse Y") * turnSpeed;

        // 水平の入力取得
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // 垂直の入力を取得
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
        // 移動ベクトルの正規化
        movement.Normalize();

        EventMove?.Invoke(movement);
        // カメラの高さを保持する
        float originalCameraHeight = transform.position.y;
        // カメラの高さを元の高さに戻す
        transform.position = new Vector3(transform.position.x, originalCameraHeight, transform.position.z);
        
        // カメラの垂直方向の回転を適用する
        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0);

    }
}
