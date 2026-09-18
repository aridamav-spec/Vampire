using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemySpawn;
    [SerializeField] GameObject player;

    [SerializeField] float SpawnRate;
    float nextSpawn = 0;

    List<GameObject> enemies = new List<GameObject>();

    void Update()
    {
        nextSpawn += SpawnRate * Time.deltaTime;
        if(nextSpawn > 1)
        {
            SpawnEnemy();
            nextSpawn = 0;
        }
    }
    public void SpawnEnemy()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos.x = Random.Range(-10, 10);
        spawnPos.y = Random.Range(-10, 10);
        GameObject newenemies = Instantiate(enemySpawn, spawnPos, Quaternion.identity);
        enemies.Add(newenemies);

        newenemies.GetComponent<Enemy2D>().targetPosition = player;
    }
}
