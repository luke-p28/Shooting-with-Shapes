using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public static int phase = 0;
    int objectsPhase = 0;
    public GameObject[] phaseExclusives;

    void Start()
    {
        if (LevelManager.levelNum != -1)
            Destroy(gameObject);
        else 
          phaseExclusives[0].SetActive(true);
        phase = 0;
    }

    void EnablePhaseObjects()
    {
        if (phaseExclusives[objectsPhase])
            phaseExclusives[objectsPhase].SetActive(true);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("enemy reference");
    }

    void Update()
    {
        print("Phase: " + phase + ", Level num: " + LevelManager.levelNum);
        if (phase == 0 && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            phase = 1;
        }
        if(objectsPhase != phase)
        {
            if (phaseExclusives[objectsPhase])
                phaseExclusives[objectsPhase].SetActive(false);
            objectsPhase = phase;
            Invoke(nameof(EnablePhaseObjects), 0.5f);
            if (objectsPhase == 6)
                Invoke(nameof(ReturnToMenu), 2.5f);
        }
    }
}
