using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;

    private void Start() {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
