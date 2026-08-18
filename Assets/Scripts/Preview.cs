using UnityEngine;

public class Preview : MonoBehaviour
{
    bool movin = true;
    public bool rightTriangleFix = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerMovement.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movin)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward + (rightTriangleFix
                                                                                                          ? GetComponent<Collider2D>().bounds.extents/3
                                                                                                          : Vector3.zero);
            if (Input.GetMouseButtonDown(0))
            {
                movin = false;
                PlayerMovement.canMove = true;
                GameObject explosion = Instantiate(ShapesManager.explosionsStatic[(int)Ammo.collectedShapeType], transform.position, Quaternion.identity);
                explosion.GetComponent<Explosion>().preview = gameObject;
                explosion.SetActive(true);
            }
        }
    }
}
