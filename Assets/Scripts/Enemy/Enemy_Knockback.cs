using System.Collections;
using UnityEngine;
using static EnemyTemp;

public class Enemy_Knockback : MonoBehaviour
{
    public Rigidbody2D rb;
    public EnemyTemp enemyTemp;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        enemyTemp = transform.parent.GetComponent<EnemyTemp>();
    }

    public void Knockback(Transform playerTransform, float knockbackForce, float stunTime)
    {
        enemyTemp.StateHandler(EnemyState.Knockback);
        StartCoroutine(StunTimer(stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity = direction * knockbackForce;
        print("knockback applied");
    }

    IEnumerator StunTimer(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        enemyTemp.StateHandler(EnemyState.Idle);
    }
 
}
