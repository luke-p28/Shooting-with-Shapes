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
            Enemy leftEnemy = Instantiate(objToSpawn, transform.position, transform.rotation).GetComponent<Enemy>();
            leftEnemy.randomStart = false;
            leftEnemy.transform.position += Random.value * 10 * Vector3.forward;
            leftEnemy.movementSpeed = movementSpeed + 0.2f;
            leftEnemy.strafeSpeed = strafeSpeed + 1;
            leftEnemy.invincibleTime = 0.5f;
            Enemy rightEnemy = Instantiate(objToSpawn, transform.position, transform.rotation).GetComponent<Enemy>();
            rightEnemy.randomStart = false;
            rightEnemy.transform.position += Random.value * 10 * Vector3.forward;
            rightEnemy.movementSpeed = movementSpeed + 0.2f;
            rightEnemy.strafeSpeed = strafeSpeed - 1;
            rightEnemy.invincibleTime = 0.5f;
        }
    }
}
