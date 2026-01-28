using System.Collections;
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
    public Animator anim2;

    public float attackRadius;
    public float attackCooldown;
    private float timer;
    public bool hit;

    private void Update()
    {
        
    }



    public void Attack()
    {
       
        
        enemy.StateHandler(EnemyTemp.EnemyState.Attacking);
        anim.SetBool("Attacking", true);

        Collider2D[] playerCol = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, Player);

        foreach (Collider2D playerGameObj in playerCol)
        {
            playerGameObj.GetComponent<Stats>().currentHealth = stats.currentHealth - damage;

            hit = true;
            if (hit && !anim2.GetBool("Parry"))
            {
                player.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                stats.StartCoroutine(stats.whiteColour());
                Debug.Log("Hit");

            }

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
       

        enemy.StateHandler(EnemyTemp.EnemyState.Parried);

        yield return new WaitForSeconds(1.5f);
        
        anim.SetBool("Parried", false);
       

        enemy.StateHandler(EnemyTemp.EnemyState.Idle);
    }

}


