using UnityEngine;
using UnityEngine.Events;
using Enemys.Model;
using Data.Repository;
public class Enemy : MonoBehaviour
{
    private Transform target;
    private Rigidbody rb;
    
    private DataRepository _repository;
    [SerializeField] private GameObject Player;
    public UnityAction<float> EventDamage;
    public UnityAction EventEnemyGeneration;
    public float attackDistance = 2.0f;
    private float moveSpeed = 10f;
    public float rotationSpeed = 3.0f;
    public GameObject sword;
    public Transform swordAttackPoint;
    private Animator animator;
    private bool isAttacking = false;
    private int HP = 10;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        target = Player.GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // 重力を無効にする
    }
    public void SetDataRepository(DataRepository Repository)
    {
        _repository = Repository;
        
    }
    public void SynModel()
    {
        
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
            // 斜面の法線ベクトルを取得
            RaycastHit hit;
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            // transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                Vector3 slopeNormal = hit.normal;
                Debug.Log(moveSpeed);
                // 敵オブジェクトに力を追加
                Vector3 slopeMovement = Vector3.ProjectOnPlane(direction.normalized, slopeNormal) * moveSpeed * Time.deltaTime;
                rb.MovePosition(transform.position + slopeMovement);
                
            }
            animator.SetFloat("MoveSpeed", direction.magnitude);
            
        }
        if(HP == 0)
        {
            Die();
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
                EventDamage?.Invoke(0.1f);
                //Debug.Log("Damage");
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
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Damage(2);
            
        }
    }
    private void Damage(int damage)
    {
        HP = HP - damage;
    }
    private void Die()
    {
        EventEnemyGeneration?.Invoke();
        Destroy(this.gameObject);
    }
}

