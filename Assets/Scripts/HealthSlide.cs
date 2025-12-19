using UnityEngine;
using UnityEngine.UI;

public class HealthSlide : MonoBehaviour
{
    public Stats stats;
    public Slider slider;



    // Update is called once per frame
    void Update()
    {
        slider.value = (stats.currentHealth / stats.maxHealth);
    }
}
