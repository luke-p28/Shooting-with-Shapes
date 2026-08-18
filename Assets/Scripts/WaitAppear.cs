using UnityEngine;

public class WaitAppear : MonoBehaviour
{
    public float waitTime = 5;
    public GameObject target;
    float time = 0;

    void Start()
    {
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (time < waitTime)
        {
            time += Time.deltaTime;
            print("Time: " + time);
        } else
        {
            target.SetActive(true);
            print("Active");
            Destroy(this);
        }
    }
}
