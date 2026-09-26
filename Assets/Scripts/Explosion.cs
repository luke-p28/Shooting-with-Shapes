using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    CinemachineBasicMultiChannelPerlin cameraShaker;
    Vector3 targetScale;
    Vector3 targetProportions;
    public GameObject preview;
    SpriteRenderer thisRenderer;
    float explosionTime;
    public float explosionDuration;
    public ShapesManager.ShapeType shape;
    const float shakeTime = 0.3f;
    float shakeMagnitude;
    // public static ShapesManager.ShapeType lastKilledEnemy;
    // public static bool enemyKilled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraShaker = GameObject.Find("CinemachineCamera").GetComponent<CinemachineBasicMultiChannelPerlin>();
        shakeMagnitude = 10 - ((Vector2)transform.position).magnitude * 0.5f;
        targetScale = transform.localScale;
        targetProportions = targetScale.normalized;
        transform.localScale = targetProportions * 0.01f;
        thisRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        explosionTime += Time.deltaTime;
        if (explosionTime > shakeTime)
        {
            if (!gameObject.GetComponent<Renderer>().enabled) {
                Destroy(gameObject);
                cameraShaker.AmplitudeGain = 0;
            }
        } else
        {
            cameraShaker.AmplitudeGain = shakeMagnitude - shakeMagnitude * (2*explosionTime/shakeTime-1) * (2*explosionTime/shakeTime-1);
        }
        if (transform.localScale.magnitude < targetScale.magnitude)
        {
            //print("growing");
            transform.localScale = explosionTime / explosionDuration * (explosionTime / explosionDuration) * targetScale.magnitude * targetProportions;
        }
        else
        {
            //print("done growing");
            if (preview)
                Destroy(preview);
            if (thisRenderer.color.a > Time.deltaTime)
                thisRenderer.color = new Color(thisRenderer.color.r, thisRenderer.color.g, thisRenderer.color.b, thisRenderer.color.a - Time.deltaTime * 3);
            else
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemyComp) && !enemyComp.invincible)
        {
            enemyComp.ExplosionHit(shape);
        }
    }
}
