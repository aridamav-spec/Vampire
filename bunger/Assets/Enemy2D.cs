using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public int enemyHealth;
    int maxenemyHealth = 10;
    void Start()
    {
        enemyHealth = maxenemyHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            enemytakeDamage();
        }

    }
    public void enemytakeDamage()
    {
        enemyHealth -= 2;
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
