using UnityEngine;

public class Ammo : MonoBehaviour
{
    public static bool hasAmmo;
    public static ShapesManager.ShapeType collectedShapeType;
    public static GameObject collectedShapeObject;
    public ShapesManager.ShapeType shapeType;
    bool collectible = true;
    public static Vector3 lastPosition = Vector3.zero;
    GameObject player;

    public static ShapesManager.ShapeType lastShapeType;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!collectible)
        {
            transform.SetPositionAndRotation(player.transform.position + Vector3.back, player.transform.rotation);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // print("Last position:");
        // print(lastPosition);
        // print("colderded");
        if (collision.gameObject.CompareTag("Player"))
        {
            // print("hasAmmo: " + hasAmmo + ", pickingUp: " + PlayerMovement.pickingUp);
            if (PlayerMovement.pickingUp && (!hasAmmo || collectedShapeType != shapeType))
            {
                if (hasAmmo)
                {
                    Destroy(collectedShapeObject);
                }
                if (lastPosition != Vector3.zero)
                {
                    ShapesManager.ShapeType newShapeType;
                    newShapeType = lastShapeType;
                    lastShapeType = shapeType;
                    Instantiate(ShapesManager.ammosStatic[(int)newShapeType], lastPosition, Quaternion.identity);
                } else
                {
                    lastShapeType = shapeType;
                }
                if (LevelManager.levelNum == -1 && Tutorial.phase == 3)
                    Tutorial.phase = 4;
                lastPosition = transform.position;
                // print("colledcted");
                collectible = false;
                hasAmmo = true;
                collectedShapeObject = gameObject;
                collectedShapeType = shapeType;
                // print("now has ammo: " + hasAmmo);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // print("exxiteed");
    }
}
