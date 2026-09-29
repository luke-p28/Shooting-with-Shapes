using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void StartGame()
    {
        PlayMusic.Click();
        if (LevelManager.LevelsUnlocked == 1)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(2);
    }
    public void DoSceneSwitch(int sceneIndex)
    {
        PlayMusic.Click();
        SceneManager.LoadScene(sceneIndex);
    }
}
