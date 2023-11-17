using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    GameObject scoreUIText;

    //public float maxHealth;
    //public float currentHealth;
    [SerializeField] private float health;

    public int enemyScore;
    [SerializeField] public float moveSpeed;
    public GameObject deathAnimation;

    [SerializeField]
    private bool chasingPlayer = false; // Dí theo mục tiêu
    private SpriteRenderer spriteRenderer;

    private Transform playerTransform;
    Player playerScript;

    [SerializeField] private int enemyDamage = 10; // Damage của quái

    private bool beingAttacked = false;

    private float timeSinceSpawn; // Thời gian trôi qua kể từ khi quái sinh ra
    // Biến để lưu giữ giá trị để tăng máu và damage
    public float healthIncreaseRate = 5;
    public float damageIncreaseRate = 2;

    void Start()
    {
        try
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            playerScript = playerTransform.GetComponent<Player>();
        }
        catch { }
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //playerScript = playerTransform.GetComponent<Player>();
        //scoreUIText = GameObject.FindGameObjectWithTag("ScoreText");

        spriteRenderer = GetComponent<SpriteRenderer>();

        timeSinceSpawn = 0f; // Khởi tạo thời gian bằng 0
        StartCoroutine(IncreaseStatsOverTime());
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            // direction.x kiểm tra người chơi đang ở bên phải hay bên trái mà flipX theo
            spriteRenderer.flipX = (direction.x < 0) ? false : true;
        }

        if (chasingPlayer && playerTransform != null)
        {
            ChasePlayer();
        }
        else
        {
            MoveNormally();
        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }


        // Cập nhật thời gian đã trôi qua (Để cứ 1 phút quái sẽ tăng máu và dmg)
        timeSinceSpawn += Time.deltaTime;

    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (health <= 0)
            {
                Die();
            }

            // Gây sát thương cho người chơi
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(enemyDamage);
            }
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(deathAnimation);
        explosion.transform.position = transform.position;
    }

    // Hàm để thực hiện hành động theo đuổi người chơi
    void ChasePlayer()
    {
        // Đặt khoảng cách offset từ Player
        float offsetDistance = 8f;
        // Khoảng cách (tầm) muốn kiểm tra với Enemy
        float detectionRange = Random.Range(8f, 32f);
        //float detectionRange = 10f;


        // Tính khoảng cách giữa enemy và Player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        // Tính toán hướng từ enemy đến player
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        // Tính toán vị trí mới dựa trên hướng và khoảng cách offSet
        Vector3 targetPosition = playerTransform.position - directionToPlayer * offsetDistance;

        // Kiểm tra nếu khoảng cách hiện tại nhỏ hơn khoảng cách cho trước
        if (distanceToPlayer < detectionRange)
        {
            // Enemy đi thẳng đến player nếu khoảng cách hiện tại đã ở trong tầm cho trước
            transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Di chuyển enemy đến vị trí mới
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        
    }


    // Hàm để thực hiện hành động di chuyển xuống dưới Map khi Player Die
    void MoveNormally()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - moveSpeed * Time.deltaTime * 2);
        transform.position = position;
    }

    void Die()
    {
        // Gọi ra từ hàm LootBag để quái rớt đồ
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        PlayExplosion();
        Destroy(gameObject);
        Debug.Log("Enemy die");
        // Tăng Exp cho người chơi khi quái chết
        // hoặc muốn hợp lý thì tách riêng ra để khi đánh được quái thì bật, tránh khi quái tự đụng cũng có exp
        playerScript.IncreaseExp(enemyScore);
    }

    public bool IsBeingAttacked()
    {
        return beingAttacked;
    }

    public float GetHealth()
    {
        return health;
    }

    IEnumerator IncreaseStatsOverTime()
    {
        while (true)
        {
            // Tăng máu và damage
            health += healthIncreaseRate;
            enemyDamage += Mathf.RoundToInt(damageIncreaseRate);

            // Thời gian trước khi tăng tiếp
            yield return new WaitForSeconds(60f); // Tăng lên sau khoảng 1 phút
        }
    }
}