using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;

    public float max;

    public float strength
    {
        get
        {
            return max - health;
        }

        set
        {
            health = max - value;
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
