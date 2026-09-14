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
    float ProjectileSpeed = 3f;
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
        autoAttack();

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
    void autoAttack()
    {
        if (!alreadyAttacked)
        {
            Rigidbody2D rb = Instantiate(Weapon, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            rb.AddForce(transform.forward * ProjectileSpeed, ForceMode2D.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    } 
}
