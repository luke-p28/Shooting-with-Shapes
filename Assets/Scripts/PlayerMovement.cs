using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public static bool canMove = true;
    public static bool pickingUp;
    Color pickingUpColor;
    Color normalColor;
    new SpriteRenderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        normalColor = renderer.color;
        Color.RGBToHSV(normalColor, out float h, out float s, out float v);
        pickingUpColor = Color.HSVToRGB(h, s, v - 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pickingUp = true;
            renderer.color = pickingUpColor;
        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            pickingUp = false;
            renderer.color = normalColor;
        }
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            //transform.Rotate(0, 0, 1f);
            Vector2 targetDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (targetDirection == Vector2.zero)
                targetDirection = transform.forward;
            else
                transform.Translate(Vector3.up * speed / 60, Space.Self);
            Vector2 currentDirection = transform.up;
            if (Vector3.Angle(currentDirection, targetDirection) > 90.1f)
                targetDirection = Quaternion.Euler(0, 0, 90) * currentDirection;
            Quaternion neededRotation = Quaternion.FromToRotation(currentDirection, targetDirection);
            // print(neededRotation);
            // print(targetDirection);
            // print(currentDirection);
            // print("e");
            // print(neededRotation * currentDirection);
            transform.Rotate(Quaternion.SlerpUnclamped(Quaternion.identity, neededRotation.normalized, 0.5f).eulerAngles);
            //transform.Rotate(0, 0, -1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.otherCollider.gameObject.name);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Stage"))
        {
            LivesManager.DecrementLives();
            gameObject.transform.position = Vector3.zero;
            print("left platform");
        }
        
    }
}
