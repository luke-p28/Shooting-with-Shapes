using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public static float progress;
    new public static GameObject gameObject;
    public GameObject bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject = base.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        bar.transform.localScale = new(progress, bar.transform.localScale.y, bar.transform.localScale.z);
    }
}
