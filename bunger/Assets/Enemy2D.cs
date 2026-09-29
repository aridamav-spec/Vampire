using UnityEngine;
using System.Collections.Generic;
public class Enemy2D : MonoBehaviour
{
    public float enemyHealth;
    public float maxenemyHealth;
    public float speed = 1f;
    public int giveXP = 10;
    public GameObject sphereObject;
    public GameObject Orb;
    public Transform player;
    public GameObject targetPosition;
    // [Range (0f, 5f)]
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
        if (PlayerBehaviour.killCount >= 10)
        {
            IncreaseHP();
        }
    }
    public void enemytakeDamage()
    {
        enemyHealth -= Weapon.damage;
        if (enemyHealth <= 0)
        {
            PlayerBehaviour.killCount++;
            Die();
        }
    }
 /*   public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            PlayerBehaviour.killCount++;
            Die();
        }
    } */
    public void Die()
    {
        Vector3 spawnPos3 = new Vector3(transform.position.x, transform.position.y, 0f);
        GameObject orb = Instantiate(Orb, spawnPos3, Quaternion.identity);
    }
    public void IncreaseHP()
    {
        maxenemyHealth += 2;
    }
}
