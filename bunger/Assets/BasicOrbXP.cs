using UnityEngine;

public class BasicOrbXP : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
