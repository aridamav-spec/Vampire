using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Enemy"))
        {
            other.GetComponent<Enemy2D>().enemytakeDamage();
            Destroy(gameObject);
        }
    }
}
