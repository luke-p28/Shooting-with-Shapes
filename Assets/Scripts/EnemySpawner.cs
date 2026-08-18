using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using TrueRandom = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer = 1;
    float spawnTime;
    public GameObject[] enemies;
    public int enemyLimit;
    int offset;
    // Random random;
    Random shapeTypeRandom;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = Mathf.FloorToInt(TrueRandom.Range(0, enemies.Length - 1));
        shapeTypeRandom = new(LevelManager.levelNum);
        // random = new(LevelManager.levelNum);
        Enemy.random = new(LevelManager.levelNum);
        Enemy.speedRandom = new(LevelManager.levelNum);
        Enemy.offset = TrueRandom.value * 360;
        Enemy.isFirst = true;
        Explosion.enemyKilled = false;
        Explosion.enemiesKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > spawnTimer && (LevelManager.levelNum != -1 || Tutorial.phase == 1))
        {
            GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (currentEnemies.Length < enemyLimit)
            {
                if (LevelManager.levelNum == -1){
                    Instantiate(enemies[3]);
                    Tutorial.phase = 2;
                }
                else
                    Instantiate(enemies[(shapeTypeRandom.Next(0,enemies.Length) + offset)%enemies.Length]);
                // GetCurrentShapes(out var inPlay, out var outOfPlay);
                // if(inPlay.Count == 0 && Explosion.enemyKilled)
                // {
                //     outOfPlay.Remove(Explosion.lastKilledEnemy);
                //     inPlay.Add(Explosion.lastKilledEnemy);
                // }
                // if(inPlay.Count > 0 && outOfPlay.Count > 0)
                // {
                //     if(random.NextDouble() <= LevelManager.dupeChance[LevelManager.levelNum - 1])
                //         Instantiate(enemies[(int)inPlay[TrueRandom.Range(0, inPlay.Count - 1)]]);
                //     else
                //         Instantiate(enemies[(int)outOfPlay[TrueRandom.Range(0, outOfPlay.Count - 1)]]);
                // }
                // else
                //     Instantiate(enemies[TrueRandom.Range(0, enemies.Length)]);
            }
            spawnTime -= spawnTimer;
        }
    }

    public static bool IsEnemyWithType(ShapesManager.ShapeType type)
    {
        GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < currentEnemies.Length; i++)
        {
            if (currentEnemies[i].TryGetComponent(out Enemy component))
            {
                if (component.shapeType == type) return true;
            }
        }
        return false;
    }

    void GetCurrentShapes(out List<ShapesManager.ShapeType> inPlay, out List<ShapesManager.ShapeType> outOfPlay)
    {
        inPlay = new();
        outOfPlay = new();
        List<bool> shapesInPlay = new();
        for (int i = 0; i < enemies.Length; i++)
        {
            shapesInPlay.Add(false);
        }
        // print("shapesinplay length: " + shapesInPlay.Count);
        // print("enemies length: " + enemies.Length);
        GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in currentEnemies)
        {
            if(enemy.TryGetComponent(out Enemy component))
            {
                shapesInPlay[(int)component.shapeType] = true;
            }
        }
        for (int i = 0; i < shapesInPlay.Count; i++)
        {
            if(shapesInPlay[i])
                inPlay.Add((ShapesManager.ShapeType)i);
            else
                outOfPlay.Add((ShapesManager.ShapeType)i);
        }
    }
}
