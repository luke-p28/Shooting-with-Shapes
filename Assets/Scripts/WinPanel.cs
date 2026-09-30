using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    static GameObject winObj;
    static GameObject loseObj;
    public bool isWin;
    void Start()
    {
        if(isWin)
            winObj = gameObject;
        else
            loseObj = gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Win(bool updateLevel)
    {
        LivesManager.inGame = false;
        LevelManager.WinRate *= 2.0f/3;
        ScreenFlasher.flashTimer = 0;
        // print("winning");
        if (updateLevel){
            winObj.SetActive(true);
            LevelManager.WinRate += 1.0f/3;
        }
        else
            loseObj.SetActive(true);
        Time.timeScale = 0;
        if (updateLevel && LevelManager.levelNum == LevelManager.LevelsUnlocked)
            ++LevelManager.LevelsUnlocked;
    }

    public void NextLevel()
    {
        ++LevelManager.levelNum;
        Time.timeScale = 1;
        if (LevelManager.levelNum == LevelManager.enemyCounts.Length + 1)
            SceneManager.LoadScene(4);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }

    public void EnemyReference()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(6);
    }
}
