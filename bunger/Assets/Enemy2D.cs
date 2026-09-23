using UnityEngine;
using System.Collections;
public class Enemy2D : MonoBehaviour
{
    public float enemyHealth;
    public float maxenemyHealth;
    float deathCounter;
    public int giveXP = 10;
    public GameObject sphereObject;
    public GameObject Orb;
    public Transform player;
    public GameObject targetPosition;
    [Range (0f, 5f)]
    public float speed = 1.0f;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        enemyHealth = maxenemyHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            enemytakeDamage();
        }
        if (targetPosition != null)
        {
            sphereObject.transform.position = Vector2.MoveTowards(sphereObject.transform.position, player.transform.position, speed * Time.deltaTime);
        }
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
    public void Die()
    {
        Destroy(gameObject);
        Vector3 spawnPos3 = new Vector3(transform.position.x, transform.position.y, 0f);
        GameObject orb = Instantiate(Orb, spawnPos3, Quaternion.identity);
    }
    public void IncreaseHP()
    {
        maxenemyHealth += 2;
    }
}
