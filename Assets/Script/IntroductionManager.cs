using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionManager : MonoBehaviour
{
    public string homeSceneName = "SampleScene";

    public void GoToHome()
    {
        SceneManager.LoadScene(homeSceneName);
    }
}