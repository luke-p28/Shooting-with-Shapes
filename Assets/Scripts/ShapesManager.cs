using System.Collections;
using UnityEngine;
using Random = System.Random;

public class ShapesManager : MonoBehaviour
{
    public enum ShapeType
    {
        Square,
        Circle,
        Triangle,
        RightTriangle,
        Rhombus,
        Parellelogram,
    }
    public GameObject[] explosions;
    public static GameObject[] explosionsStatic;
    public GameObject[] previews;
    public static GameObject[] previewsStatic;
    public GameObject[] ammos;
    public static GameObject[] ammosStatic;
    void Start()
    {
        Random random = new(LevelManager.levelNum+5);
        explosionsStatic = explosions;
        previewsStatic = previews;
        ammosStatic = ammos;
        Ammo.hasAmmo = false;
        Ammo.collectedShapeObject = null;
        Ammo.lastPosition = Vector3.zero;
        // GameObject[] ammosInScene = GameObject.FindGameObjectsWithTag("Ammo");
        // SortedList objects = new();
        // SortedList newPositions = new();
        // for (int i = 0; i < ammosInScene.Length; i++)
        // {
        //     objects.Add(ammosInScene[i].name,ammosInScene[i]);
        // }
        // // if (LevelManager.levelNum == -1)
        // // {
        // //     for (int i = 0; i < ammosInScene.Length; i++)
        // //     {
        // //         newPositions.Add(i,((GameObject)objects.GetByIndex(i)).transform.position);
        // //     }
        // // } else {
        // for (int i = 0; i < ammosInScene.Length; i++)
        // {
        //     newPositions.Add(random.NextDouble(),((GameObject)objects.GetByIndex(i)).transform.position);
        // }
        // // }
        // for (int i = 0; i < ammosInScene.Length; i++)
        // {
        //     ((GameObject)objects.GetByIndex(i)).transform.position = (Vector3)newPositions.GetByIndex(i);
        // }
        // // print("Sorted positions: ");
        // // foreach(DictionaryEntry thing in positions){print((Vector3)thing.Value);}
    }
}
