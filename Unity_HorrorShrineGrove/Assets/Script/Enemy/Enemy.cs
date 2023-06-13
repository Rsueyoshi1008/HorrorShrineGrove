using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Enemys.Model;
using Data.Repository;
public class Enemy : MonoBehaviour
{
    private Transform target;
    private Rigidbody rb;
    private NavMeshAgent myAgent;
    
    private DataRepository _repository;
    private GameManager gameManager;
    private EnemyModel _model;
    [SerializeField] private GameObject Player;
    public UnityAction<float> EventDamage;
    public UnityAction EventEnemyGeneration;
    public float attackDistance = 2.0f;
    private float moveSpeed = 20f;
    public float rotationSpeed = 3.0f;
    public GameObject sword;
    public Transform swordAttackPoint;
    private Animator animator;
    private bool isAttacking = false;
    private int HP = 10;
    
    void Start()
    {
        
        
        
    }
    public void InitializeDataRepository()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
        myAgent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _repository = gameManager.GetDataRepository();
        _model = new EnemyModel();
    }
    public void SynModel()
    {
        var enemy = _repository.enemy[0];
        _model.AchievementEnemy = enemy.AchievementEnemy;
        _model.OverthrowEnemy = enemy.OverthrowEnemy;
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
            
            myAgent.SetDestination(target.position);
            animator.SetFloat("MoveSpeed", direction.magnitude);
            
        }
        if(HP == 0)
        {
            _model.OverthrowEnemy++;
            if(_model.OverthrowEnemy == _model.AchievementEnemy)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("GameClearScene");
            }
            SyncRepository();
            //Debug.Log(_model.OverthrowEnemy);
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
    public void SyncRepository()
    {
        _repository.enemy[0].OverthrowEnemy = _model.OverthrowEnemy;
        Debug.Log(_repository.enemy[0].OverthrowEnemy);
    }
}

