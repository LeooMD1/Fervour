using System.Collections;
using UnityEngine;

public class emenyAttack : MonoBehaviour
{

    public LayerMask Player;
    public playerAttack attack;
    
    public GameObject attackPoint;
    public GameObject attackPoint2;
    public GameObject player;
    public Stats stats;
    public EnemyTemp enemy;
    public float damage;
    public Animator anim;

    public float attackRadius;
    public float attackCooldown;
    private float timer;
    public bool hit;

    private void Update()
    {
        /*attackCooldown -= Time.deltaTime;
        if (attackCooldown < 0)
        {
            anim.SetBool("Attacking", false);
            print("cooldown?");
            attackCooldown = 3;
        }*/
    }

    public void Attack()
    {
       
        
        enemy.StateHandler(EnemyTemp.EnemyState.Attacking);
        anim.SetBool("Attacking", true);

        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, Player);

        foreach (Collider2D playerGameObj in player)
        {
            playerGameObj.GetComponent<Stats>().currentHealth = stats.currentHealth - damage;

            hit = true;
  
            if (attack.isParrying)
            {
                StartCoroutine(Parried()); 
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

    public IEnumerator Parried()
    {
  
        stats.currentHealth = stats.currentHealth + stats.parryHealth;
        anim.SetBool("Parried", true);

        enemy.StateHandler(EnemyTemp.EnemyState.Idle);

        yield return new WaitForSeconds(2);
        
        anim.SetBool("Parried", false);

        print("parried");
        
    }

}


