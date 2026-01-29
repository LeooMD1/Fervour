using System.Collections;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dropForce;
    public float maxHealthReduction;
    public float healthRegain;

    public GameObject player;
    public Stats stats;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        stats = player.GetComponent<Stats>();
        
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);

        StartCoroutine(Despawn());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player == collision.gameObject)
        {
            stats.maxHealth = stats.maxHealth - maxHealthReduction;
            stats.currentHealth = stats.currentHealth + healthRegain;
            GameObject.Destroy(gameObject);
        }
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(20);
        GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        new WaitForSeconds(0.5f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        new WaitForSeconds(0.5f);
        GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        new WaitForSeconds(0.5f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        new WaitForSeconds(3);
        GameObject.Destroy(gameObject);
    }
}
