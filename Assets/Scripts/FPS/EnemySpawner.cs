using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float secondsPerSpawn = 3;
    private float lastSpawnTime = 0;
    [SerializeField] private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Spawn()
    {
        GameObject enemyPrefab = enemies[Random.Range(0, enemies.Length)];
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

            secondsPerSpawn -= (0.05f * Time.deltaTime);
            if (Time.time - lastSpawnTime >= secondsPerSpawn && FPSPlayer.instance.ShouldSpawn(transform.position))
            {
                lastSpawnTime = Time.time;
                Spawn();
            }
        }
}
