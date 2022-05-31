using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
   public void Level1Loader()
    {
        SceneManager.LoadScene(6);
    }
    public void Level2Loader()
    {
        SceneManager.LoadScene(7);
    }
    public void Level3Loader()
    {
        SceneManager.LoadScene(8);
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
