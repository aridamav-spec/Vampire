using UnityEngine;
public class PlayerBehaviour : MonoBehaviour
{
    public float playerSpeed = 1.0f;
    private int maxHealth = 100;
    public int currentHealth;
    public Transform enemy;
    public HP healthBar;
    public int playerDamage;
    public float timeBetweenAttacks;
    public GameObject Weapon;
    bool alreadyAttacked;
    public float ProjectileSpeed = 10f;
    public float attackRange;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
            mouseWorld.z = 0f;
            Vector3 spawnPos3 = new Vector3(transform.position.x, transform.position.y, 0f);
            Vector2 dir = new Vector2(mouseWorld.x - spawnPos3.x, mouseWorld.y - spawnPos3.y).normalized;

            GameObject proj = Instantiate(Weapon, spawnPos3, Quaternion.identity);
            if (proj == null)
            {
                Debug.LogError("PlayerBehaviour: Instantiate returned null");
                return;
            }

            // Set projectile damage if the projectile script exists
            Weapon wp = proj.GetComponent<Weapon>();
            if (wp != null)
            {
                wp.damage = playerDamage;
            }
            else
            {
                Debug.Log("PlayerBehaviour: Weapon prefab has no Weapon component.");
            }

            // Destroy the spawned weapon after 5 seconds
            Destroy(proj, 5f);

            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = dir * ProjectileSpeed;
            }
        }

        if (horizontalInput > 0)
        {
            Flip(true);
        }
        else if (horizontalInput  < 0)
        {
            Flip(false);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    void Flip(bool facingRight)
    {
        Vector3 scale = transform.localScale;
        scale.x = facingRight ? 1 : -1;
        transform.localScale = scale;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit Player!222");
        TakeDamage(10);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Still Hitting Player!");
        TakeDamage(1);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
