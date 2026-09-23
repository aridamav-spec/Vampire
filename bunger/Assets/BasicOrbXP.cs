using UnityEngine;

public class BasicOrbXP : MonoBehaviour
{
    public int XP = -10;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehaviour>().GetXP();
            Destroy(gameObject);
        }
    }
}
