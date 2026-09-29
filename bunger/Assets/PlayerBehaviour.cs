using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour
{
    public static float playerSpeed = 2.0f;
    private int maxHealth = 200;
    public static int needXP = 100;
    public int currentXP;
    public static int xpLevel = 0;
    public int currentHealth;
    public static float killCount = 0;
    public static int eliteCounter = 0;
    public Transform enemy;
    public HP healthBar;
    public XP xpBar;
    public int playerDamage;
    public static float timeBetweenAttacks = 1f;
    public bool alreadyAttacked;
    public GameObject Weapon;
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
    public void UpdatePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        transform.Translate(movement * (playerSpeed * Time.deltaTime));

        if (alreadyAttacked == false && Input.GetMouseButton(0))
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
            mouseWorld.z = 0f;
            Vector3 spawnPos3 = new Vector3(transform.position.x, transform.position.y, 0f);
            Vector2 dir = new Vector2(mouseWorld.x - spawnPos3.x, mouseWorld.y - spawnPos3.y).normalized;

            GameObject proj = Instantiate(Weapon, spawnPos3, Quaternion.identity);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
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
    void ResetAttack()
    {
        alreadyAttacked = false;
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
        currentXP -= BasicOrbXP.OrbGive;
        xpBar.SetXP(currentXP);
        if (currentXP <= 0)
        {
            needXP = (int)(needXP * 1.2f);
            currentXP = needXP;
            xpBar.SetNeedXP(needXP);
            xpLevel++;
            GameManager.Instance.ChangeState<UpgradeState>();
        }
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
