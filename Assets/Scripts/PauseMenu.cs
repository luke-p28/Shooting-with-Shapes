using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject visuals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        visuals.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            visuals.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void LevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level select");
    }

    public void EnemyReference()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("enemy reference");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        visuals.SetActive(false);
    }
}
