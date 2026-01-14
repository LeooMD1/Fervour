using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSlider : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public Slider slider;
    

    // Update is called once per frame
    void Update()
    {
        slider.value = (enemyHealth.currentHealth / enemyHealth.maxHealth);
    }
}
