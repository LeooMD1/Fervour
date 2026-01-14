using System.Threading.Tasks;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            print("enemy killed");
            gameObject.SetActive(false);
            

            
        }
    }
}
