using UnityEngine;
public class PlayerBehaviour : MonoBehaviour
{
    public float playerSpeed = 1.0f;
    public int playerHealth = 100;
    public int playerDamage = 10;
    public int projectileDamage = 10;
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 1) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * playerSpeed * Time.deltaTime);
        }

    }
}
