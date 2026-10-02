using UnityEngine;
using System.Collections.Generic;
public class Enemy2D : MonoBehaviour
{
    public float enemyHealth;
    public float maxenemyHealth;
    public float speed = 1f;
    public int giveScore = 1;
    public int giveXP = 10;
    public GameObject sphereObject;
    public GameObject Orb;
    public Transform player;
    public GameObject targetPosition;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        enemyHealth = maxenemyHealth;
    }
    public void UpdateEnemy()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            enemytakeDamage();
        }
        Vector3 targetWorld = player != null ? player.position : Vector3.zero;
        if (targetPosition != null)
        {
            targetWorld = targetPosition.transform.position;
        }

        Transform mover = (sphereObject != null) ? sphereObject.transform : transform;
        mover.position = Vector2.MoveTowards(mover.position, targetWorld, speed * Time.deltaTime);
        if (Stats.killcounter >= 5)
        {
            maxenemyHealth++;
            Stats.killcounter = 0;
        }
    }
    public void enemytakeDamage()
    {
        enemyHealth -= Stats.weapondamage;
        if (enemyHealth <= 0)
        {
            Stats.killcounter++;
            Stats.elitecounter++;
            Stats.score += giveScore;
            Die();
        }
    }
    public void Die()
    {
        Vector3 spawnPos3 = new Vector3(transform.position.x, transform.position.y, 0f);
        GameObject orb = Instantiate(Orb, spawnPos3, Quaternion.identity);
    }
}
