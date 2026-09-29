using UnityEngine;

public class Close : MonoBehaviour
{
    public void DoClose()
    {
        PlayMusic.Click();
        Application.Quit();
    }
}
