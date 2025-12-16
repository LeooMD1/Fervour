using UnityEngine;

public class Attack : MonoBehaviour
{
    Stats stats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void attack()
    {
        var dmg = stats.strength;

    }
}
