using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour
{
    public float playerSpeed = 1.0f;
    private int maxHealth = 200;
    public static int needXP = 100;
    public int currentXP;
    public int currentHealth;
    public static float killCount = 0;
    public Transform enemy;
    public HP healthBar;
    public XP xpBar;
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
        needXP = 100;
        currentXP = needXP;
        healthBar.SetMaxHealth(maxHealth);
        xpBar.SetNeedXP(needXP);
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        transform.Translate(movement * (playerSpeed * Time.deltaTime));

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
            mouseWorld.z = 0f;
            Vector3 spawnPos3 = new Vector3(transform.position.x, transform.position.y, 0f);
            Vector2 dir = new Vector2(mouseWorld.x - spawnPos3.x, mouseWorld.y - spawnPos3.y).normalized;

            GameObject proj = Instantiate(Weapon, spawnPos3, Quaternion.identity);
    /*        if (proj == null)
            {
                return;
            }
            Weapon wp = proj.GetComponent<Weapon>();
            if (wp != null)
            {
                wp. = playerDamage;
            }
            else
            {

            } */
            Destroy(proj, 2f);

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
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetXP();
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
        TakeDamage(10);
        Debug.Log("Hit Player!222");
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
        if (currentHealth < 0)
        {
            Death();
        }
    }
    public void GetXP()
    {
        currentXP -= 10;
        xpBar.SetXP(currentXP);
        if (currentXP <= 0)
        {
            needXP = (int)(needXP * 1.1f);
            currentXP = needXP;
            xpBar.SetNeedXP(needXP);
            Debug.Log("BUSS");
        }
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
