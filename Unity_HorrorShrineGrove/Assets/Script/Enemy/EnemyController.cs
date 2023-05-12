using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f; // 敵の移動速度
    public float raycastDistance = 10f; // Raycastの距離
    public LayerMask raycastLayer; // Raycastが判定するレイヤー

    private Rigidbody rb;
    public float damage = 10f; // 攻撃のダメージ量
    public float attackRange = 2f; // 攻撃の範囲
    public float attackInterval = 2f; // 攻撃の間隔
    public LayerMask attackLayer; // 攻撃が判定するレイヤー

    private bool canAttack = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Attack();
    }


    void Attack()
    {
        if (canAttack)
        {
            // 攻撃可能な状態で、プレイヤーが攻撃範囲内にいる場合は攻撃する
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, attackLayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    //hit.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                    canAttack = false;
                    Invoke("ResetAttack", attackInterval);
                }
            }
        }
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    
    void Move()
    {
    // Raycastを飛ばしてプレイヤーを探す
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, raycastLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // プレイヤーがいる方向に移動する
                Vector3 direction = (hit.collider.transform.position - transform.position).normalized;
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
        }
    }
}