using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;


    public void LoadGame()
    {
       StartCoroutine(WaitAndLoad("Main Game", sceneLoadDelay));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void LoadBonusLevel()
    {
        StartCoroutine(WaitAndLoad("Bonus Level", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
