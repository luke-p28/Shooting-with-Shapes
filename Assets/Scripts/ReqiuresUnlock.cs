using UnityEngine;

public class ReqiuresUnlock : MonoBehaviour
{
    public int levelRequired;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (LevelManager.LevelsUnlocked < levelRequired)
        {
            gameObject.SetActive(false);
        }
    }
}
