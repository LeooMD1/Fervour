using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Stats stats;
    public Animator animator;

    public KeyCode attackButton;
    public KeyCode parryButton;

    public float knockbackForce = 50f;
    public float stunTime = 1f;
    public float attackForce = 500f;

    public EnemyHealth enemyHealth;
    public GameObject attackPoint;
    public GameObject parryPoint;
    PlayerMovement pm;
    Rigidbody2D rb;
    public float attackRadius;
    public float parryRadius;
    public LayerMask enemies;
    public int attackStage;

    public float damageOutput;

    public bool previousAttackWindow;
    public bool attackWindow;

    public bool isParrying;
    public float parryTimer = 1;
    public float parryCooldown = 1;
    
    void Start()
    {
        stats = transform.parent.GetComponent<Stats>();
        pm = transform.parent.GetComponent<PlayerMovement>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackButton))
        {
            
            animator.SetBool("Attacking", true);
            if (attackWindow)
            {
                animator.SetTrigger("atkKeyDown");
            }
        }

        if (Input.GetKeyDown(parryButton) && parryTimer <= 0)
        {         
            animator.SetBool("Parry", true);

            parryTimer = parryCooldown;

        }
           parryTimer -= Time.deltaTime;

            Dismember();
      

    }

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, enemies);
        
        foreach (Collider2D enemyGameObj in enemy)
        {
            enemyGameObj.GetComponent<EnemyHealth>().currentHealth -= damageOutput;

            enemyGameObj.GetComponent<Enemy_Knockback>().Knockback(transform, knockbackForce, stunTime);
 
        }
    }

    public void EndAttack()
    {
        pm.speed = 10f;
        animator.SetBool("Attacking", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRadius);
        Gizmos.DrawWireSphere(parryPoint.transform.position, parryRadius);
    }

    public void Dismember()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, enemies);

        foreach (Collider2D enemyGameObj in enemy)
        {
            if (enemyGameObj.GetComponent<EnemyHealth>().currentHealth <= 30)
            {

            }
           
        }
    }

    public void attck1()
    {
        pm.speed = 0f;
     
        attackPoint.transform.localPosition = new(2.36f, -0.07f);
        attackRadius = 1f;
        damageOutput = 7 + stats.damageMult;
        knockbackForce = 2f;
    }
    
    public void attack2()
    {
        pm.speed = 0f;
        attackPoint.transform.localPosition = new(2.4f, -0.4f);
        attackRadius = 1f;
        damageOutput = 7 + stats.damageMult;
        knockbackForce = 2f;
    }
    
    
    public void attack3()
    {
        pm.speed = 0f;
        attackPoint.transform.localPosition = new(2.69f, -0.74f);
        attackRadius = 1.5f;
        damageOutput = 20 + stats.damageMult;
        knockbackForce = 10f;
    }

    public void Parry()
    {
        pm.speed = 0f;

        /*Collider2D[] enemy = Physics2D.OverlapCircleAll(parryPoint.transform.position, parryRadius, enemies);

        foreach (Collider2D enemyGameObj in enemy)
        {

        }*/



        //play enemy parry animation regardless of what it is doing at the moment


    }

    public void EndParry()
    {
        pm.speed = 10f;
        animator.SetBool("Parry", false);
    }

}
