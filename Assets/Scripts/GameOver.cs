using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float Timer = 1f;
    public float currentScene;
    public GameObject Main;

    public Stats stats;

    private void Start()
    {
        Main.SetActive(false);
    }


    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;

        if (stats.currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void Continue()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        print("quit");
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //anim.SetTrigger("Start");
        yield return new WaitForSeconds(Timer);
        SceneManager.LoadScene(levelIndex);
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        Main.SetActive(true);

    }
}
