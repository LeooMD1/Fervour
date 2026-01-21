using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class EnemyTemp : MonoBehaviour
{
    [Header("Stats")]
    public float Damage;
    public float enemySpeed;
    public float attackCooldown;
    public float attackSpeed;
    public float pursuingRange;
    public float attackRange;
    bool isFacingRight;


    public GameObject Player;
    public Animator anim;
    public Stats stats;
    public Rigidbody2D rb;
    public emenyAttack EnemyAttack;
    public Slider slider;

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

            anim.SetBool("Moving", true);

            var xd = Player.transform.position.x - gameObject.transform.position.x;
            var Horizontal = Mathf.Sign(xd);
                  
            rb.AddForce(Vector2.right * Horizontal * enemySpeed, ForceMode2D.Force);

            if (isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
                
                if (isFacingRight)
                {
                    slider.direction = Slider.Direction.RightToLeft;
                }

                else
                {
                    slider.direction = Slider.Direction.LeftToRight;
                }


            }


        }

        else
        {
            anim.SetBool("Moving", false);

            if (currentEnemyState == EnemyState.Attacking)
            {
                anim.SetBool("Attacking", true);
                rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, 0, 0.02f);
            }
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