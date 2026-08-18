using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public static int lives = 3;
    public static GameObject[] hearts;
    public GameObject[] dynamicHearts;
    public static bool inGame = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = 3;
        hearts = dynamicHearts;
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
        inGame = true;
    }

    public static void DecrementLives()
    {
        if(inGame){
            print("Lives: " + lives);
            if (lives == 0)
                return;
            --lives;
            hearts[lives].SetActive(false);
            if (lives == 0)
            {
                WinPanel.Win(false);
            }
        }
    }
}
