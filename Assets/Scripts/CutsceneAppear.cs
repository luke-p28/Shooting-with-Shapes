using UnityEngine;
using System;

[Serializable]
public class CutsceneAppear: CutsceneMaker.CutsceneAction
{
    public float duration;
    public bool isAppearing;
    public GameObject[] objsToAppear;
    float time;
    public override void Setup()
    {
        // foreach(GameObject obj in objsToAppear)
        //     obj.SetActive(!isAppearing);
        foreach(GameObject obj in objsToAppear)
            obj.SetActive(isAppearing);
    }

    public override void DoTimestep()
    {
        time += Time.deltaTime;
    }

    public override bool IsDone()
    {
        return time >= duration;
    }
}