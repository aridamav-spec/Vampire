using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static int damage = 2;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy2D>().enemytakeDamage();
            Destroy(gameObject);
        }
    } 
}
