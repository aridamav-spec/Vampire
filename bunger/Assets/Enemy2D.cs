using UnityEngine;
using System.Collections;
public class Enemy2D : MonoBehaviour
{
    public int enemyHealth;
    int maxenemyHealth = 10;

    public GameObject sphereObject;
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
    }

    public void enemytakeDamage()
    {
        enemyHealth -= 5;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}
