using System.Collections;
using UnityEngine;

public class ProjectileScript : PlayerBehaviour
{
    void Start()
    {
        
        
    }
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            playerHealth -= projectileDamage;
            Destroy(gameObject);
        }
    }
}
