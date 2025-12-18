using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public GameObject PauseMenu,PauseButton;
    public static bool isPaused = false;
    // Start is called before the first frame update
   public void restart()
   {
        Resume();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
   }
    public void MainMenu()
    {
        Resume();
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
        PauseButton.gameObject.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void Paused()
    {
        PauseButton.gameObject.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    private void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame


}
