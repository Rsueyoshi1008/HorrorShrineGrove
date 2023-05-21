using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform traget;

    public UnityAction<float,float,float,Transform> EventMove;

    private float MoveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        EventMove?.Invoke(horizontalInput,verticalInput,MoveSpeed,traget);
    }
}
