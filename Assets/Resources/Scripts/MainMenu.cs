using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Text versionTextUiText;

    private void Start() {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        versionTextUiText.text = $"Version : {Application.version}";
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
