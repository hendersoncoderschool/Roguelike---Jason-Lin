using UnityEngine;

public class CoinGravitation : MonoBehaviour
{
    public Transform playerPosition;
    public Player player;
    public Rigidbody2D rb;
    public float followDistance;
    public float followSpeed;
    public bool chasing;
    void Start()
    {
        //Variables
        playerPosition = GameObject.Find("Player").transform;
        player = GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        chasing = false;

        //Random Spawn Force
        rb.AddForce(Random.insideUnitCircle.normalized * 1.5f,ForceMode2D.Impulse);

        //Start Check Distance
        InvokeRepeating("CheckDistance", 0f, 0.1f);
    }
    void Update()
    {
        if (chasing&&Time.timeScale!=0)
        {
            Vector2 direction = ((Vector2)playerPosition.position - (Vector2)transform.position);
            transform.up = direction;
            rb.AddForce(transform.up * followSpeed);
        }
    }
    void CheckDistance()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) < followDistance)
        {
            chasing = true;
            rb.linearDamping = 3.0f;
        }
        else
        {
            chasing = false;
            rb.linearDamping = 1.25f;
        }
        if(Vector2.Distance(transform.position, playerPosition.position)<0.4f)
        {
            player.totalCoins++;
            Destroy(gameObject);
        }
    }
}