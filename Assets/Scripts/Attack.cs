using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Stats stats;
    public Animator animator;

    public KeyCode attackButton;

    public EnemyHealth enemyHealth;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;

    public float damageOutput;
    
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackButton))
        {
            animator.SetBool("Attacking", true);           
        }

        Dismember();
       
        
    }

    public void Attack()
    {
        
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        
        foreach (Collider2D enemyGameObj in enemy)
        {
            enemyGameObj.GetComponent<EnemyHealth>().health -= damageOutput;
            print(enemyGameObj.GetComponent<EnemyHealth>().health);
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
            if (enemyGameObj.GetComponent<EnemyHealth>().health <= 30)
            {

            }
           
        }
    }

}
