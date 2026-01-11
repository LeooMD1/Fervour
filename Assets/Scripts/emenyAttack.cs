using UnityEngine;

public class emenyAttack : MonoBehaviour
{
   
    
    public GameObject player;
    public Stats stats;
    public EnemyTemp enemy;
    public float damage;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (player == collision.gameObject)
            {
                stats.currentHealth = stats.currentHealth - damage;
                print("dead");
            }
        
    }
}
