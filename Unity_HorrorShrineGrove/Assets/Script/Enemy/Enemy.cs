using UnityEngine;
using UnityEngine.Events;
using Enemys.Model;
using Data.Repository;
public class Enemy : MonoBehaviour
{
    private Transform target;
    private EnemyModel _model;
    private DataRepository _repository;
    [SerializeField] private GameObject Player;
    public UnityAction<int> EventDamage;
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
        target = Player.GetComponent<Transform>();
    }
    public void SetDataRepository(DataRepository Repository)
    {
        _repository = Repository;
        _model = new EnemyModel();
    }
    public void SynModel()
    {
        var enemy = _repository.enemy[0];

        _model.HP = enemy.HP;
        _model.ATK = enemy.ATK;
        _model.DEF = enemy.DEF;
        _model.Speed = enemy.Speed;

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
                EventDamage?.Invoke(_model.ATK);
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
        // if(other.gameObject.tag == "Player")
        // {
        //     
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.None;
        // }
    }
    
}

