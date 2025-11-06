using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public string homeSceneName = "MainMenu";

    public void GoToHome()
    {
        SceneManager.LoadScene(homeSceneName);
    }
}