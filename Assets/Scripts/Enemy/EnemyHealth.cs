using System.Threading.Tasks;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float maxHealth;
    public GameObject enemyObj;

    public EnemyTemp EnemyTemp;

    //public Animatior anim;


    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            print("enemy killed");
            // add animation od enemy dying
            //anim.setbool("dying", true);
            
            //temp as there is no death animation yet
            Object.Destroy(enemyObj);



        }
        HealthDifference();
    }

    public void DestroyEnemy()
    {
        //make event within the animation so that the gameobject is destroyed on the last frame of the animation
        Object.Destroy(enemyObj);
    }

    // check health difference 
    public void HealthDifference()
    {
        health = currentHealth;
        if (currentHealth < health)
        {
            print("test");
            EnemyTemp.currentEnemyState = EnemyTemp.EnemyState.Knockback;
        }

    }



}
