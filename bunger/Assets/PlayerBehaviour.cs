using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour
{
    private int maxHealth = 200;
    public float currentXP;
    public int currentHealth;
    public int damageFrames = 0;
    public Transform enemy;
    public HP healthBar;
    public XP xpBar;
    public int playerDamage;
    public bool alreadyAttacked;
    public GameObject Weapon;
    public float ProjectileSpeed = 10f;
    public float attackRange;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        currentHealth = maxHealth;
        Stats.xpneeded = 100;
        currentXP = Stats.xpneeded;
        healthBar.SetMaxHealth(maxHealth);
        xpBar.SetNeedXP(Stats.xpneeded);
    }
    public void UpdatePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        transform.Translate(movement * (Stats.playerspeed * Time.deltaTime));

        if (alreadyAttacked == false && Input.GetMouseButton(0))
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
            mouseWorld.z = 0f;
            Vector3 spawnPos3 = new Vector3(transform.position.x, transform.position.y, 0f);
            Vector2 direction = new Vector2(mouseWorld.x - spawnPos3.x, mouseWorld.y - spawnPos3.y).normalized;

            GameObject projectile = Instantiate(Weapon, spawnPos3, Quaternion.identity);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), Stats.attackspeed);
            Destroy(projectile, 2f);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * ProjectileSpeed;
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
        if (currentXP <= 0)
        {
            Stats.xpneeded *= 1.2f;
            currentXP = Stats.xpneeded;
            xpBar.SetNeedXP(Stats.xpneeded);
            Stats.xplevel++;
            GameManager.Instance.ChangeState<UpgradeState>();
        }
    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageFrames++;
            if (damageFrames >= 30)
            {
                TakeDamage(10);
                damageFrames = 0;
            }
        }
    }

    void Flip(bool facingRight)
    {
        Vector3 scale = transform.localScale;
        scale.x = facingRight ? 1 : -1;
        transform.localScale = scale;
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
        currentXP -= Stats.orbgive;
        xpBar.SetXP(currentXP);
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigXPOrb"))
        {
            currentXP -= Stats.orbgive * 4;
            xpBar.SetXP(currentXP);
        }
        if (collision.CompareTag("SmallXPOrb"))
        {
            currentXP -= Stats.orbgive;
            xpBar.SetXP(currentXP);
        }
    }
}
