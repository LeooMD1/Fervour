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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
