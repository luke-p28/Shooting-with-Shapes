using UnityEngine;

public class MakeStars : MonoBehaviour
{
    public float upper;
    public float lower;
    public float start;
    public float end;
    public float speed;
    public bool yes;
    public float speedlower;
    public float speedupper;
    Vector3 startpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (yes)
        {
            Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero) + Vector3.left + Vector3.down;
            Vector3 upperRight = Camera.main.ScreenToWorldPoint(new(Camera.main.pixelWidth + 10,Camera.main.pixelHeight,0));
            end = bottomLeft.x;
            start = upperRight.x;
            upper = upperRight.y;
            lower = bottomLeft.y;
            transform.position = Vector3.zero + Vector3.forward*2 + Vector3.right*start;
            startpos = transform.position;
            InvokeRepeating("makething", 0, 0.1f);
        }
    }

    void makething() {
        transform.position += Vector3.up * UnityEngine.Random.Range(lower, upper);
        GameObject newStar = Instantiate(gameObject, transform.position, transform.rotation);
        MakeStars comp = newStar.GetComponent<MakeStars>();
        newStar.GetComponent<Renderer>().enabled = true;
        comp.speed = UnityEngine.Random.Range(speedlower, speedupper);
        comp.yes = false;
        transform.position = startpos;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed);
        if (transform.position.x < end)
            Destroy(gameObject);
    }
}
