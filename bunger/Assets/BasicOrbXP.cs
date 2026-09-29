using UnityEngine;

public class BasicOrbXP : MonoBehaviour
{
    public int CustomizeXP = 10;
    public static int OrbGive;
    private void Start()
    {
        OrbGive = CustomizeXP;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehaviour>().GetXP();
            Destroy(gameObject);
        }
    }
}
