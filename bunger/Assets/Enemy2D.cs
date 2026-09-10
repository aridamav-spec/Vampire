using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    int enemyHealth;
    int maxenemyHealth;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void takeDamage()
    {
        enemyHealth--;
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
