using UnityEngine;
using UnityEngine.UI;

public class ScreenFlasher : MonoBehaviour
{
    const float flashTime = 0.3f;
    const float flashMagnitude = 0.3f;
    const float shakeMagnitude = 8;
    public static float flashTimer = 0;
    static float r,g,b;
    Image imageComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imageComponent = GetComponent<Image>();
        imageComponent.enabled = true;
        Color color = imageComponent.color;
        r = color.r;
        g = color.g;
        b = color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (flashTimer > 0){
            imageComponent.color = new(r,g,b,flashMagnitude - flashMagnitude * Mathf.Abs(2*flashTimer/flashTime-1));
            flashTimer -= Time.deltaTime;
        } else
        {
            imageComponent.color = new(r,g,b,0);
        }
    }
    public static void Flash()
    {
        Camera.main.GetComponent<CameraShake>().StartCameraShake(shakeMagnitude, flashTime);
        flashTimer = flashTime;
    }
}
