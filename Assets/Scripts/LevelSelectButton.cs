using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    public int levelNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (levelNum > LevelManager.LevelsUnlocked)
        {
            // print("darkening");
            var renderer = GetComponent<Image>();
            Color.RGBToHSV(renderer.color, out var h, out var s, out var v);
            renderer.color = Color.HSVToRGB(h, s, v - 0.3f);
            GetComponent<Button>().enabled = false;
        }
    }

    public void GoToLevel()
    {
        LevelManager.levelNum = levelNum;
        SceneManager.LoadScene(3);
    }
}
