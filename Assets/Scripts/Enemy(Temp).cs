using UnityEngine;

public class EnemyTemp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float Damage;
    
    public GameObject Player;
    public Stats stats;

    void Start()
    {
         stats = Player.GetComponent<Stats>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Player == collision.gameObject)
        {
            stats.currentHealth = stats.currentHealth - Damage;
            print("dead");
        }
    }
}