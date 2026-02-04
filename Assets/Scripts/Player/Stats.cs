using System.Collections;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public float maxMaxHealth;
    public float damageMult;
    public float parryHealth;
    public emenyAttack emenyAttack;
    public playerAttack attack;
    public Animator anim;


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
        parryHealth = emenyAttack.damage + 5f;

        

    }

    public void Death()
    {
        gameObject.SetActive(false);
        
    }

    public IEnumerator whiteColour()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        emenyAttack.hit = false;

    }

    
}
