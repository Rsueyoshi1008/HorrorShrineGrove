using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform target;
    //Playerの制御イベント
    public UnityAction<Transform> EventTransform;
    public UnityAction<Transform> EventDebugTest;

    private float MoveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //初期化
    public void Initialization()
    {
        EventTransform?.Invoke(target);
        //EventDebugTest?.Invoke(target);
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
    }
}
