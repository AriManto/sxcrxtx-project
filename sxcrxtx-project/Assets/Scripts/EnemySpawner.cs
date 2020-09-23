using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int MaxEnemiesAllowed { get; set; }
    public float TimeIntervalMS { get; set; }
    public bool IsActive { get; set; }

    public int minX = 78;
    public int minY = 55;
    public int maxX = 1800;
    public int maxY = 894;

    // Start is called before the first frame update
    void Start()
    {
        IsActive = true; //test
        /*
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        /*
         THIS SHIT IS B R O K E N   X XD
         */
        if (!IsActive)
        {
            Enemy newEnemy = gameObject.AddComponent<Enemy>();
            newEnemy.CollisionDamage = 1;
            newEnemy.StartingHitpoints = 3;
            newEnemy.Health = gameObject.AddComponent<HealthSystem>();
            //newEnemy.Health.Hitpoints = 3;
            newEnemy.Size = 1;
            newEnemy.tag = "Enemy";
            GameObject.Instantiate(newEnemy, GenerateSpawnPosition(), new Quaternion(0, 0, 0, 0));
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        int randomX = Random.Range(minX, maxX);
        int randomY = Random.Range(minY, maxY);
        Vector3 randomPosition = new Vector3(randomX, randomY,0);
        return randomPosition;
    }
    void Shutdown()
    {
        this.IsActive = false;
    }
    void SetIntervalInSeconds(int seconds)
    {
        this.TimeIntervalMS = seconds * 1000;
    }
}
