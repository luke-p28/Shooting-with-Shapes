using UnityEngine;

public class BossEnemy : Enemy
{
    public static EnemySpawner.EnemyTypePrefabs enemies;
    protected override int livesLost()
    {
        return 3;
    }
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
            Spawn(enemies[(int)EnemySpawner.GetNextEnemyType()], 0.1f, 1);
            Spawn(enemies[(int)EnemySpawner.GetNextEnemyType()], 0.1f, -1);
        }
    }
}
