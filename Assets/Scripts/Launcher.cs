using UnityEngine;

public class Launcher : MonoBehaviour
{
    public ShapesManager.ShapeType shapeType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // print("colidered with: " + collision.gameObject.name);
        // print("has ammo: " + Ammo.hasAmmo);
        // print("shape type: " + Ammo.collectedShapeType);
        if (collision.gameObject.CompareTag("Player") && Ammo.hasAmmo && Ammo.collectedShapeType == shapeType)
        {
            // print(Ammo.collectedShapeObject.name);
            Destroy(Ammo.collectedShapeObject);
            // print(Ammo.collectedShapeObject.name);
            Ammo.hasAmmo = false;
            Instantiate(ShapesManager.previewsStatic[(int)Ammo.collectedShapeType]);
            if (LevelManager.levelNum == -1 && Tutorial.phase == 4)
                Tutorial.phase = 5;
        }
    }
}
