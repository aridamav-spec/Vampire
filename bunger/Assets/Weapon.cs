using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy2D>().takeDamage();
        }
    }
}
