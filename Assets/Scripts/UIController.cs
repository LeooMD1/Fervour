using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("--------References--------")]

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public Stats stats;
    public Animator playerAnim;
    public Image Ability1;
    public Image Ability2;
    public Image Ability3;
    public TextMeshProUGUI CooldownText1;
    public TextMeshProUGUI CooldownText2;
    public TextMeshProUGUI CooldownText3;

    

    [Header("--------Variables--------")]

    public float lerpTime;
    public float CooldownTime;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.maxHealth <= 75)
        {
            Item1.SetActive(true);
        }
        
        if (playerAnim.GetBool("Wing") == true)
        {
            StartCoroutine(AbilityCooldown());
        }
    }

    private IEnumerator AbilityCooldown()
    {
        Ability1.color = Color.black;
        
        if (CooldownTime > 0)
        {
            CooldownTime -= Time.deltaTime;
        }

        else if (CooldownTime < 0)
        {
            CooldownTime = 0;
        }
        int seconds = Mathf.FloorToInt(CooldownTime % 60);
        CooldownText1.text = seconds.ToString();

        yield return new WaitForSeconds(30);
        Ability1.color = Color.white;
    }
}
