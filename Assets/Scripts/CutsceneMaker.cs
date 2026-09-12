using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneMaker : MonoBehaviour
{
    public int nextScene;
    public enum ActionType
    {
        Movement,
        Appearing,
    }


    public abstract class CutsceneAction
    {
        public abstract void DoTimestep();
        public abstract bool IsDone();
        public abstract void Setup();
    }

    public ActionType[] actionOrder;
    public CutsceneMovement[] movements;
    public CutsceneAppear[] appears;
    List<CutsceneAction[]> cutsceneActions = new();
    int[] actionsIndices;
    void Start()
    {
        cutsceneActions.Add(movements);
        cutsceneActions.Add(appears);
        actionsIndices = new int[cutsceneActions.Count];
        currentAction = cutsceneActions[(int)actionOrder[currentMovement]][actionsIndices[(int)actionOrder[currentMovement]]];
        actionsIndices[(int)actionOrder[currentMovement]]++;
        currentAction.Setup();
    }
    int currentMovement;
    CutsceneAction currentAction;
    void Update()
    {
        if(currentAction.IsDone())
        {
            ++currentMovement;
            if (currentMovement == actionOrder.Length)
            {
                LevelManager.levelNum = -1;
                SceneManager.LoadScene(nextScene);
            } else
            {
                currentAction = cutsceneActions[(int)actionOrder[currentMovement]][actionsIndices[(int)actionOrder[currentMovement]]];
                actionsIndices[(int)actionOrder[currentMovement]]++;
                currentAction.Setup();
            }
        } else
        {
            currentAction.DoTimestep();
        }
    }
}
