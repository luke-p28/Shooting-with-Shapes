using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (LevelManager.LevelsUnlocked == 1)
            Destroy(gameObject);
    }

    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
