using UnityEngine;

public class BossEnemy : Enemy
{
    public static EnemySpawner.EnemyTypePrefabs enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        movementSpeed /= 5;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void ExplosionHit(ShapesManager.ShapeType explosionType)
    {
        if (explosionType == shapeType)
        {
            Destroy(gameObject);
            Enemy leftEnemy = Instantiate(enemies[(int)EnemySpawner.GetNextEnemyType()], transform.position, transform.rotation).GetComponent<Enemy>();
            leftEnemy.randomStart = false;
            leftEnemy.transform.position += Random.value * 10 * Vector3.forward;
            leftEnemy.movementSpeed = movementSpeed + 0.1f;
            leftEnemy.strafeSpeed = strafeSpeed + 0.5f;
            Enemy rightEnemy = Instantiate(enemies[(int)EnemySpawner.GetNextEnemyType()], transform.position, transform.rotation).GetComponent<Enemy>();
            rightEnemy.randomStart = false;
            rightEnemy.transform.position += Random.value * 10 * Vector3.forward;
            rightEnemy.movementSpeed = movementSpeed + 0.1f;
            rightEnemy.strafeSpeed = strafeSpeed - 0.5f;
        }
    }
}
