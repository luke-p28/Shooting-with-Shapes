using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CinemachineBasicMultiChannelPerlin cameraShaker;
    void Start()
    {
        cameraShaker = GameObject.Find("CinemachineCamera").GetComponent<CinemachineBasicMultiChannelPerlin>();
    }
    IEnumerator ShakeCamera(float magnitude, float length)
    {
        float startingTime = Time.time;
        while(Time.time - startingTime < length)
        {
            cameraShaker.AmplitudeGain = magnitude - magnitude * (2*(Time.time - startingTime)/length-1) * (2*(Time.time - startingTime)/length-1);
            yield return new WaitForEndOfFrame();
        }
        cameraShaker.AmplitudeGain = 0;
    }

    internal void StartCameraShake(float magnitude, float length)
    {
        StartCoroutine(ShakeCamera(magnitude, length));
    }
}
