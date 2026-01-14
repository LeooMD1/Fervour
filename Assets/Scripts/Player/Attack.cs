using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Stats stats;
    public Animator animator;

    public KeyCode attackButton;

    public float knockbackForce = 50f;
    public float stunTime = 1f;
    public float attackForce = 500f;

    public EnemyHealth enemyHealth;
    public GameObject attackPoint;
    PlayerMovement pm;
    Rigidbody2D rb;
    public float radius;
    public LayerMask enemies;
    public int attackStage;

    public float damageOutput;

    public bool previousAttackWindow;
    public bool attackWindow;
    
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
           

            Dismember();
      

    }

    public void Attack()
    {
        
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        
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
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    public void Dismember()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

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

        if (pm.isFacingRight)
        {
            rb.AddForce(Vector2.right * attackForce, ForceMode2D.Impulse);
        }
        else
            rb.AddForce(Vector2.left * attackForce, ForceMode2D.Impulse);

        attackPoint.transform.localPosition = new(2.36f, -0.07f);
        radius = 0.7f;
        damageOutput = 10;
    }
    
    public void attack2()
    {
        pm.speed = 0f;

        attackPoint.transform.localPosition = new(2.4f, -0.4f);
        radius = 0.7f;
        damageOutput = 15;
    }
    
    
    public void attack3()
    {
        pm.speed = 0f;

        attackPoint.transform.localPosition = new(2.69f, -0.74f);
        radius = 1.3f;
        damageOutput = 30;
    }

}
