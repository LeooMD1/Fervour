using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            print("enemy killed");
        }
    }
}
