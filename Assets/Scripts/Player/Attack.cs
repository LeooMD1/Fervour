using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Stats stats;
    public Animator animator;

    public KeyCode attackButton;

    public float knockbackStrength;

    public EnemyHealth enemyHealth;
    public GameObject attackPoint;
    PlayerMovement pm;
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
            print(enemyGameObj.GetComponent<EnemyHealth>().currentHealth);
            
            var attackDirection = Vector2.zero;
            if (pm.isFacingRight)            
                attackDirection = Vector2.right;           

            else
                attackDirection = Vector2.left;

            print(attackDirection);
            enemyGameObj.transform.parent.GetComponent<Rigidbody2D>().AddForce(attackDirection *  knockbackStrength, ForceMode2D.Impulse);
           
        }
    }

    public void EndAttack()
    {
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
        attackPoint.transform.localPosition = new(2.36f, -0.07f);
        radius = 0.7f;
        damageOutput = 15;
    }
    
    public void attack2()
    {
        attackPoint.transform.localPosition = new(2.4f, -0.4f);
        radius = 0.7f;
        damageOutput = 15;
    }
    
    
    public void attack3()
    {
        attackPoint.transform.localPosition = new(2.69f, -0.74f);
        radius = 1.3f;
        damageOutput = 30;

    }

}
