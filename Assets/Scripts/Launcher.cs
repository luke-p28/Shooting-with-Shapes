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
        if (collision.gameObject.CompareTag("Player") && Ammo.hasAmmo && Ammo.collectedShapeType == shapeType)
        {
            Destroy(Ammo.collectedShapeObject);
            Instantiate(ShapesManager.ammosStatic[(int)Ammo.lastShapeType], Ammo.lastPosition, Quaternion.identity);
            Ammo.hasAmmo = false;
            Instantiate(ShapesManager.previewsStatic[(int)Ammo.collectedShapeType]);
            if (LevelManager.levelNum == -1 && Tutorial.phase == 4)
                Tutorial.phase = 5;
        }
    }
}
