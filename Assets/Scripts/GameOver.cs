using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float Timer = 1f;
    public void Continue()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
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
}
