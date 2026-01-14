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
    public float kbMult;

    public GameObject Player;
    public Stats stats;
    public Rigidbody2D rb;

    public enum EnemyState
    {
        Attacking,
        Idle,
        Pursuing
    }
    public EnemyState currentEnemyState;



    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }
   
    public void StateHandler()
    {
        var distance = Vector2.Distance(Player.transform.position, gameObject.transform.position);

        if (distance < attackRange)
            currentEnemyState = EnemyState.Attacking;

        else if (distance < pursuingRange)
            currentEnemyState = EnemyState.Pursuing;

        else currentEnemyState = EnemyState.Idle;
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
            var breakingForce = Vector3.right * 10;
            
            rb.AddForce(breakingForce * -Mathf.Sign(rb.linearVelocityX), ForceMode2D.Force);
            
        }

        if (currentEnemyState == EnemyState.Idle)
        {
            var breakingForce = Vector3.right * 10;

            rb.AddForce(breakingForce * -Mathf.Sign(rb.linearVelocityX), ForceMode2D.Force);
        }
    }
    
    private void Update()
    {
        StateHandler();
        BehaviourHandler();
    }

}