using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public GameObject PauseMenu,PauseButton,GameOverUiMenu,GameWinUiMenu;
    public static bool isPaused = false;

    private void Awake() {
        Instance = this;
    }

    public void restart() {
        Resume();
        SceneManager.LoadScene("Game");
    }
    public void MainMenu() {
        Resume();
        SceneManager.LoadScene("MainUi");
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            }
            else {
                Paused();
            }
        }
    }
    public void Resume() {
        PauseButton.gameObject.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void Paused() {
        PauseButton.gameObject.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    private void Start() {
        PauseMenu.SetActive(false);
        GameOverUiMenu.SetActive(false);
        GameWinUiMenu.SetActive(false);
    }

    public void PlayerDead() {
        GameOverUiMenu.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void PlayerWon() {
        GameWinUiMenu.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void Exit() {
        Application.Quit();
    }
}
