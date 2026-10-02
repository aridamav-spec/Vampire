using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemySpawn;
    [SerializeField] GameObject eliteEnemy;
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;

    [SerializeField] float SpawnRate;
    [SerializeField] float eliteSpawnRate;
    float nextSpawn = 0;
    float nexteliteSpawn = 0;
    List<GameObject> enemies = new List<GameObject>();
    public void UpdateSpawn()
    {
        nextSpawn += SpawnRate * Time.deltaTime;
        if(nextSpawn > 1)
        {
            SpawnEnemy();
            nextSpawn = 0;
        }
        nexteliteSpawn += eliteSpawnRate * Time.deltaTime;
        if (Stats.elitecounter >= 30)
        {
            SpawnEliteEnemy();
            Stats.elitecounter = 0;
        }
        for (int i = enemies.Count -1; i >= 0; i--)
        {
            Enemy2D currentEnemy = enemies[i].GetComponent<Enemy2D>();
            if (currentEnemy.enemyHealth <= 0)
            {
                enemies.RemoveAt(i);
                Destroy(currentEnemy.gameObject);
            }
            else
            {
                currentEnemy.UpdateEnemy();
            }
        }
        if (Stats.xplevel == 0)
        {
            Stats.elitecounter = 30;
            SpawnRate = 0.5f;
        }
        if (Stats.xplevel == 5)
        {
            Stats.elitecounter = 20;
            SpawnRate = 1;
        }
        if (Stats.xplevel == 8)
        {
            Stats.elitecounter = 10;
            SpawnRate = 2;
        }
        if (Stats.xplevel >= 10)
        {
            Stats.elitecounter = 5;
            SpawnRate = 2.5f;
        }
    }
    public void SpawnEnemy()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-5, 5);
        spawnPos.y = Random.Range(-5, 5);
        GameObject newenemies = Instantiate(enemySpawn, spawnPos, Quaternion.identity);
        enemies.Add(newenemies);

        newenemies.GetComponent<Enemy2D>().targetPosition = player;
    }
    public void SpawnEliteEnemy()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-5, 5);
        spawnPos.y = Random.Range(-5, 5);
        GameObject newenemies = Instantiate(eliteEnemy, spawnPos, Quaternion.identity);
        enemies.Add(newenemies);

        newenemies.GetComponent<Enemy2D>().targetPosition = player;
    }
}
