using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Main Game");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
