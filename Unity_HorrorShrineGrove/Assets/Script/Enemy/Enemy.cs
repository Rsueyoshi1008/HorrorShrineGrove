using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float attackDistance = 2.0f;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 3.0f;
    public GameObject sword;
    public Transform swordAttackPoint;

    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null) return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < attackDistance && !isAttacking)
        {
            isAttacking = true;
            Attack();
        }
        else
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            animator.SetFloat("MoveSpeed", direction.magnitude);
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider[] hitPlayers = Physics.OverlapSphere(swordAttackPoint.position, 1.0f);
        foreach (Collider player in hitPlayers)
        {
            if (player.CompareTag("Player"))
            {
                player.GetComponent<PlayerHealth>().TakeDamage(10);
            }
        }

        Invoke("ResetAttack", 1.0f);
    }

    void ResetAttack()
    {
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (swordAttackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(swordAttackPoint.position, 1.0f);
    }
}