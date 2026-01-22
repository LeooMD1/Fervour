using UnityEngine;

public class emenyAttack : MonoBehaviour
{

    public LayerMask Player;
    public playerAttack attack;
    
    public GameObject attackPoint;
    public GameObject player;
    public Stats stats;
    public EnemyTemp enemy;
    public float damage;
    public Animator anim;

    public float attackRadius;
    public float attackCooldown;
    public bool hit;

    private void Update()
    {
        /*attackCooldown -= Time.deltaTime;
        if (attackCooldown < 0)
        {
            anim.SetBool("Attacking", false);
            
            attackCooldown = 3;
        }*/
    }

    public void Attack()
    {
       
        
        enemy.StateHandler(EnemyTemp.EnemyState.Attacking);

        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, Player);

        foreach (Collider2D playerGameObj in player)
        {
            playerGameObj.GetComponent<Stats>().currentHealth = stats.currentHealth - damage;

            hit = true;
  
            if (attack.isParrying)
            {
                playerGameObj.GetComponent<Stats>().currentHealth = stats.currentHealth + stats.parryHealth;
                anim.SetTrigger("Parried");

                print("parried");
            }

            //potential player knockback for a future time
            
            //playerGameObj.GetComponent<Enemy_Knockback>().Knockback(transform, knockbackForce, stunTime);

        }
    }

    public void EndAttack()
    {
        anim.SetBool("Attacking", false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRadius);
    }

}


