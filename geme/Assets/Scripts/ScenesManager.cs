using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    public Animator transition;
    private void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        HomeScreen,
        Introduction,
        Level1_Test,
        GayCrouds,
        S
    }

    public void LoadScene(Scene scene)
    {
        ColorManager.clone_spawn = 0;
        SceneManager.LoadScene(scene.ToString());   
    }

    public void LoadNewGame()
    {
        ColorManager.clone_spawn = 0;
        SceneManager.LoadScene(Scene.Level1_Test.ToString());
    }
    public void LoadNextScene()
    {
        StartCoroutine(NextScene());
    }

    public void MainMenu()
    {
        ColorManager.clone_spawn = 0;
        ColorManager.color_code = -1;
        SceneManager.LoadScene(Scene.HomeScreen.ToString());
    }

    public void RestartScene()
    {
        Debug.Log("Restarting Level");
        ColorManager.clone_spawn = 0;
        ColorManager.color_code = -1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator NextScene()
    {
        Debug.Log("Changing Scene...");
        ColorManager.clone_spawn = 0;
        ColorManager.color_code = -1;
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
    }

    public void EndGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    
}