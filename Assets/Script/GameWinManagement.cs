using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour
{
    public string homeSceneName = "MainMenu";

    public void GoToHome()
    {
        SceneManager.LoadScene(homeSceneName);
    }
}