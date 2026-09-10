using UnityEngine;
public class PlayerBehaviour : MonoBehaviour
{
    public float playerSpeed = 1.0f;
    private int maxHealth;
    public int currentHealth;
    public int playerDamage;
    void Start()
    {
        currentHealth = 100;
        transform.position = new Vector3(0, 0, -1);
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 1, 0) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -1, 0) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * playerSpeed * Time.deltaTime);
        }

        if (horizontalInput > 0)
        {
            Flip(true);
        }
        else if (horizontalInput  < 0)
        {
            Flip(false);
        }
    }

    void Flip(bool facingRight)
    {
        Vector3 scale = transform.localScale;
        scale.x = facingRight ? 1 : -1;
        transform.localScale = scale;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Enemy"))
        {
            print("Hit Player!");
            currentHealth -= 10;
        }
    }
}
