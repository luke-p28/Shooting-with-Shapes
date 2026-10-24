using UnityEngine;

public class SpawnerEnemy : Enemy
{
    public GameObject objToSpawn;
    protected override int livesLost()
    {
        return 2;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        movementSpeed /= 4;
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
            Spawn(objToSpawn, 0.2f, 1);
            Spawn(objToSpawn, 0.2f, -1);
        }
    }
}
