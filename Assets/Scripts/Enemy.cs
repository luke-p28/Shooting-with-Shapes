using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;
using TrueRandom = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    protected float movementSpeed;
    public ShapesManager.ShapeType shapeType;
    public float startingDistance;
    public static Random random;
    public static Random speedRandom;
    public static float offset;
    public static bool isFirst;
    static float lastAngle;
    int enemyCount;
    public static int enemiesKilled = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        if (LevelManager.levelNum != -1)
            enemyCount = LevelManager.enemyCounts[LevelManager.levelNum - 1];
        float nextDouble = (float)random.NextDouble();
        print("Next dobule: " + nextDouble);
        float angle;
        if (LevelManager.levelNum == -1)
        {
            angle = nextDouble * 360;
        } else
        {
            angle =  (nextDouble * 360 + offset) % 360;
            print("offset:" + offset);
            print("angl: " + angle);
            if (!isFirst){
                float difference = angle - lastAngle;
                if (Mathf.Abs(difference) < 90)
                {
                    print("smol angl");
                    angle = lastAngle + Mathf.Clamp(Mathf.Abs(difference), 0, 30) * Mathf.Sign(difference);
                } else if(Mathf.Abs(difference) > 270)
                {
                    print("smol big angl");
                    print("diff: " + difference);
                    angle = lastAngle + Mathf.Clamp(Mathf.Abs(difference), 330, 360) * Mathf.Sign(difference);
                } else
                {
                    print("biig angl");
                    angle = lastAngle + Mathf.Clamp(Mathf.Abs(difference), 135, 225) * Mathf.Sign(difference);
                }
            } else isFirst = false;
        }
        transform.position = Quaternion.Euler(0, 0, angle) * Vector2.up * startingDistance;
        // print("creating with offset: " + offset);
        transform.rotation = Quaternion.FromToRotation(transform.up, -transform.position.normalized);
        if (Mathf.Abs(transform.rotation.eulerAngles.x) == 180 || transform.rotation.eulerAngles == new Vector3(0,180,180))
        {
            transform.rotation = Quaternion.Euler(0,0,180);
        } else
        {
            // print("r0t: " + transform.rotation.eulerAngles);
        }
        transform.position += TrueRandom.value * 10 * Vector3.forward;
        lastAngle = angle;
        print("Final angle: " + lastAngle);

        if (LevelManager.levelNum == -1)
            movementSpeed = 0.3f;
        else
            movementSpeed = LevelManager.speedMins[LevelManager.levelNum-1] + ((float)speedRandom.NextDouble())*(LevelManager.speedMaxes[LevelManager.levelNum-1] - LevelManager.speedMins[LevelManager.levelNum-1]);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (LevelManager.levelNum != -1 || Tutorial.phase == 2)
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.up);
        if (Tutorial.phase == 2 && ((Vector2)transform.position).magnitude < 7)
            Tutorial.phase = 3;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            Destroy(gameObject);
            print("enemy hit: " + gameObject.name);
            LivesManager.DecrementLives();
        }
    }

    protected void EnemyKilled()
    {
        if (gameObject) Destroy(gameObject);
        ++enemiesKilled;
        if(enemiesKilled >= enemyCount)
        {
            WinPanel.Win(true);
        }
    }

    public virtual void ExplosionHit(ShapesManager.ShapeType explosionType)
    {
        if (shapeType == explosionType){
            Destroy(gameObject);
            if (LevelManager.levelNum == -1)
            {
                Tutorial.phase = 6;
            } 
            else EnemyKilled();
        }
    }
}
