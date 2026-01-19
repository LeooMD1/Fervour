using UnityEngine;

public class Stats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public float total;

    public float strength
    {
        get
        {
            return total - maxHealth;
        }

        set
        {
            maxHealth = total - value;
        }
    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {         
            Death();
        }
    }

    public void Death()
    {
        GameObject.Destroy(gameObject);
    }
}
