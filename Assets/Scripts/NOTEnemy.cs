using UnityEngine;

public class NOTEnemy : Enemy
{
    public GameObject xObj;
    protected override int livesLost()
    {
        return 2;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override protected void Start()
    {
        base.Start();
        movementSpeed /= 2;
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
    }

    public override void ExplosionHit(ShapesManager.ShapeType explosionType)
    {
        if (xObj && explosionType != shapeType) {Destroy(xObj); movementSpeed += 0.3f;}
        else if (!xObj && explosionType == shapeType) EnemyKilled();
    }
}
