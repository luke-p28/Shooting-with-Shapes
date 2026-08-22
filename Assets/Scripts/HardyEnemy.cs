using UnityEngine;

public class HardyEnemy : Enemy
{
    public GameObject secondShapeObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        movementSpeed /= 3;
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
            if (secondShapeObj) {Destroy(secondShapeObj); movementSpeed += 0.3f;}
            else EnemyKilled();
        }
    }
}
