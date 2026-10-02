using UnityEngine;

public class Weapon : MonoBehaviour
{
    int Damage;
    private void Start()
    {
        Damage = Stats.weapondamage;
    }
    public void WeaponUpdate()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy2D>().enemytakeDamage();
            Destroy(gameObject);
        }
    } 
}
