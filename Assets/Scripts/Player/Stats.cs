using System.Collections;
using Unity.VisualScripting;
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

        if (emenyAttack.hit)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
            StartCoroutine(whiteColour());
            Debug.Log("Hit");
            
        }


        /*else if (emenyAttack.wasParried)
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
        Debug.Log("Parry");*/
    }

    public void Death()
    {
        GameObject.Destroy(gameObject);
        
    }

    private IEnumerator whiteColour()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        emenyAttack.hit = false;

    }
}
