using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            rb.velocity = direction.normalized * moveSpeed;

            // プレイヤーの方向を向く
            transform.up = direction;
        }
    }

    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }
}