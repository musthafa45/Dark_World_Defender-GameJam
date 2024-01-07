using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused = false;
    // Start is called before the first frame update
   public void restart()
   {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");

   }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainUi");

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
   public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void Paused()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Update is called once per frame


}
