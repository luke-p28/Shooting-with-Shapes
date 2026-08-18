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
    public static ShapesManager.ShapeType lastKilledEnemy;
    public static bool enemyKilled;
    public static int enemiesKilled = 0;
    int enemyCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (LevelManager.levelNum != -1)
            enemyCount = LevelManager.enemyCounts[LevelManager.levelNum - 1];
        targetScale = transform.localScale;
        targetProportions = targetScale.normalized;
        transform.localScale = targetProportions * 0.01f;
        thisRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.magnitude < targetScale.magnitude)
        {
            //print("growing");
            explosionTime += Time.deltaTime;
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
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemyComp))
        {
            if (enemyComp.shapeType == shape){
                if(collision.gameObject.TryGetComponent(out Enemy component))
                {
                    enemyKilled = true;
                    lastKilledEnemy = component.shapeType;
                }
                Destroy(collision.gameObject);
                if (LevelManager.levelNum == -1)
                {
                    Tutorial.phase = 6;
                } else
                {
                    ++enemiesKilled;
                    if(enemiesKilled >= enemyCount)
                    {
                        WinPanel.Win(true);
                    }
                }
            }
        }
    }
}
