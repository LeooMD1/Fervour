using UnityEngine;

public class Stats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public float maxMaxHealth;
    public float damageMult;

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

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        maxHealth = Mathf.Clamp(maxHealth, 0, maxMaxHealth);

        damageMult = strength * 0.2f;
        print (damageMult);
    }

    public void Death()
    {
        GameObject.Destroy(gameObject);
    }
}
