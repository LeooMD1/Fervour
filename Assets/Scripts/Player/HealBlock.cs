using UnityEngine;

public class HealBlock : MonoBehaviour
{

    public float Heal;

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
            stats.currentHealth = stats.currentHealth + Heal;
            print("Gained Health");
            GameObject.Destroy(gameObject);
        }        
    }
}

