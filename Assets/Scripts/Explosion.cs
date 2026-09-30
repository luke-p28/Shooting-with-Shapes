using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
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
        PlayMusic.Explosion();
        shakeMagnitude = 10 - ((Vector2)transform.position).magnitude * 0.5f;
        targetScale = transform.localScale;
        targetProportions = targetScale.normalized;
        transform.localScale = targetProportions * 0.01f;
        thisRenderer = GetComponent<SpriteRenderer>();
        Camera.main.GetComponent<CameraShake>().StartCameraShake(shakeMagnitude, shakeTime);
    }

    // Update is called once per frame
    void Update()
    {
        explosionTime += Time.deltaTime;
        if (explosionTime > shakeTime)
        {
            if (!gameObject.GetComponent<Renderer>().enabled) {
                Destroy(gameObject);
            }
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
