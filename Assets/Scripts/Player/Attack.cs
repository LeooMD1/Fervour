using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Stats stats;
    public Animator animator;
    public Animator enemyAnim;

    AudioManager audioManager;
    public AudioSource audioSource;

    public KeyCode attackButton;
    public KeyCode parryButton;
    public KeyCode wingButton;

    public float knockbackForce = 50f;
    public float stunTime = 1f;
    public float attackForce = 500f;

    public EnemyHealth enemyHealth;
    public GameObject attackPoint;
    public GameObject parryPoint;
    public GameObject wingPoint;
    PlayerMovement pm;
    Rigidbody2D rb;
    public float attackRadius;
    public float parryRadius;
    public float wingRadius;
    public LayerMask enemies;
    public int attackStage;

    public float damageOutput;

    public bool previousAttackWindow;
    public bool attackWindow;
    public bool enemyStagger;
    public bool Staggered;

    public bool isParrying;
    public float parryTimer = 1;
    public float parryCooldown = 1;

    public float wingTimer = 3;
    public float wingCooldown = 3;

    public float attackTimer = 2;
    public float attackCooldown = 2;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //audioSource = GameObject.FindGameObjectWithTag("VFX").GetComponent<AudioSource>();
    }

    void Start()
    {
        stats = transform.parent.GetComponent<Stats>();
        pm = transform.parent.GetComponent<PlayerMovement>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackButton) && attackTimer <=0)
        {
            
            animator.SetBool("Attacking", true);
            if (attackWindow)
            {
                animator.SetTrigger("atkKeyDown");
            }
        }

        attackTimer -= Time.deltaTime;

        if (Input.GetKeyDown(parryButton) && parryTimer <= 0)
        {         
            animator.SetBool("Parry", true);
            animator.SetBool("Attacking", false);

            parryTimer = parryCooldown;

        }
        parryTimer -= Time.deltaTime;

            //Dismember();
        
        /*if (enemyStagger)
        {
            Staggered = true;

            if (Staggered)
            {
                enemyAnim.SetBool("Staggered", true);
                StartCoroutine(staggerTime());
            }
            
        }*/

        //else
            //enemyAnim.SetBool("Staggered", false);

        if (Input.GetKeyDown(wingButton) && stats.maxHealth <= 75 && wingTimer <=0)
        {
            animator.SetBool("Wing", true);

            wingTimer = wingCooldown;
        }

        wingTimer -= Time.deltaTime;


    }

    /*private IEnumerator staggerTime()
    {
        yield return new WaitForSeconds(50);
        Staggered = false;
    }*/

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

        attackTimer = attackCooldown;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRadius);
        Gizmos.DrawWireSphere(parryPoint.transform.position, parryRadius);
        Gizmos.DrawWireSphere(wingPoint.transform.position, wingRadius);
    }

    /*public void Dismember()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, enemies);

        foreach (Collider2D enemyGameObj in enemy)
        {
            if (enemyGameObj.GetComponent<EnemyHealth>().currentHealth <= 30)
            {

            }
           
        }
    }*/

    public void attck1()
    {
        audioManager.PlaySFX(audioManager.Attack);
        audioSource.pitch = UnityEngine.Random.Range(1.2f, 1.4f); 

        pm.speed = 0f;
     
        attackPoint.transform.localPosition = new(2.36f, -0.07f);
        attackRadius = 1f;
        damageOutput = 7 + stats.damageMult;
        knockbackForce = 2f;
    }
    
    public void attack2()
    {
        audioManager.PlaySFX(audioManager.Attack);
        audioSource.pitch = UnityEngine.Random.Range(1f, 1.2f);

        pm.speed = 0f;
        attackPoint.transform.localPosition = new(2.4f, -0.4f);
        attackRadius = 1f;
        damageOutput = 7 + stats.damageMult;
        knockbackForce = 2f;
    }
    
    
    public void attack3()
    {
        audioManager.PlaySFX(audioManager.Attack);
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);


        pm.speed = 0f;
        attackPoint.transform.localPosition = new(2.69f, -0.74f);
        attackRadius = 1.5f;
        damageOutput = 20 + stats.damageMult;
        knockbackForce = 10f;

        
    }

    public void WingAttackBehaviour()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(wingPoint.transform.position, wingRadius, enemies);

        foreach (Collider2D enemyGameObj in enemy)
        {
            enemyGameObj.GetComponent<EnemyHealth>().currentHealth -= (damageOutput + 10);

            enemyGameObj.GetComponent<Enemy_Knockback>().Knockback(transform, knockbackForce, stunTime);
        }
    }

    public void WingAttack()
    {
        pm.speed = 0f;
        damageOutput = 40 + stats.damageMult;
        knockbackForce = 10f;
    }

    public void EndWingAttack()
    {
        pm.speed = 10f;
        animator.SetBool("Wing", false);
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

    //Sound stuff for sprite cus this script is ON the sprite

    public void WalkSFX()
    {
       // while (true)
        //{
            //if (animator.GetFloat("Speed") != 0f)
            //{
                //audioManager.PlaySFX(audioManager.Walking);
           // }
       // }
        
        
        
    }

}
