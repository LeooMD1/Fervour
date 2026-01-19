using UnityEngine;

public class EnemyTemp : MonoBehaviour
{
    [Header("Stats")]
    public float Damage;
    public float enemySpeed;
    public float attackCooldown;
    public float attackSpeed;
    public float pursuingRange;
    public float attackRange;
   
    public GameObject Player;
    public Stats stats;
    public Rigidbody2D rb;
    public emenyAttack EnemyAttack;

    public enum EnemyState
    {
        Attacking,
        Idle,
        Pursuing,
        Knockback,
        Parried
    }
    public EnemyState currentEnemyState;



    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }
   
    public void StateHandler(EnemyState newState)
    {
        var distance = Vector2.Distance(Player.transform.position, gameObject.transform.position);

        if (currentEnemyState != EnemyState.Knockback)
        {

            if (distance < attackRange)
            currentEnemyState = EnemyState.Attacking;


            else if (distance < pursuingRange)
            currentEnemyState = EnemyState.Pursuing;

            else currentEnemyState = EnemyState.Idle;
        }
    }

    public void BehaviourHandler()
    {
        
        

            if (currentEnemyState == EnemyState.Pursuing)
            {
                var xd = Player.transform.position.x - gameObject.transform.position.x;
                if (xd < 0)
                {
                    rb.AddForce(Vector2.left * enemySpeed, ForceMode2D.Force);
                
                }
                else if (xd > 0)
                {
                     rb.AddForce(Vector2.right * enemySpeed, ForceMode2D.Force);
                }
            }
            if (currentEnemyState == EnemyState.Attacking)
            {
                EnemyAttack.Attack();
                rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, 0, 0.02f);            
            }

            if (currentEnemyState == EnemyState.Idle)
            {
                rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, 0, 0.02f);            
            }
        
    }
    
    private void Update()
    {
        StateHandler(currentEnemyState);
        BehaviourHandler();
    }

}