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
    }
}
