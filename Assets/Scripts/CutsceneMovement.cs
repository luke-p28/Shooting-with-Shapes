using UnityEngine;
using System;

[Serializable]
public class CutsceneMovement: CutsceneMaker.CutsceneAction
{
    public Transform ending;
    public float speed;
    float distanceRemaining = Mathf.Infinity;
    Vector3 movementDirection;
    public GameObject[] objsToMove;
    public override void Setup()
    {
        objsToMove[0].transform.position = objsToMove[0].transform.position;
        distanceRemaining = (ending.position - objsToMove[0].transform.position).magnitude;
        movementDirection = (ending.position - objsToMove[0].transform.position).normalized;
    }
    public override void DoTimestep()
    {
        foreach (GameObject obj in objsToMove)
        {
            obj.transform.Translate(movementDirection * Time.deltaTime * speed);
        }
        distanceRemaining -= Time.deltaTime * speed;
    }
    public override bool IsDone()
    {
        return distanceRemaining <= 0;
    }
}