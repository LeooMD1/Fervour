using System.Threading.Tasks;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float maxHealth;
    public GameObject enemyObj;

    public EnemyTemp EnemyTemp;

    public GameObject[] ItemDrops;

    //public Animatior anim;

    private void Start()
    {
        health = currentHealth;       
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            print("enemy killed");
            ItemDropping();
            // add animation od enemy dying
            //anim.setbool("dying", true);
            
            //temp as there is no death animation yet
            Object.Destroy(enemyObj);

            if (currentHealth < health)
            {
                print("test");
                EnemyTemp.currentEnemyState = EnemyTemp.EnemyState.Knockback;
                /*health = currentHealth;
                EnemyTemp.currentEnemyState = EnemyTemp.EnemyState.Idle;*/

            }


        }
    }

    public void DestroyEnemy()
    {
        //make event within the animation so that the gameobject is destroyed on the last frame of the animation
        Object.Destroy(enemyObj);
    }

    // check health difference 
    private void FixedUpdate()
    {       
        health = currentHealth;       
    }

    private void ItemDropping()
    {
        for (int i = 0; i < ItemDrops.Length; i++)
        {
            Instantiate(ItemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }



}
