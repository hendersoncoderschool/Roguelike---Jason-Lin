using UnityEngine;

public class CoinGravitation : MonoBehaviour
{
    public Transform playerPosition;
    public Rigidbody2D rb;
    public float followDistance;
    public float followSpeed;
    public bool chasing;
    void Start()
    {
        playerPosition = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        chasing = false;
        InvokeRepeating("CheckDistance", 0f, 0.3f);
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
        if (Vector2.Distance(transform.position, playerPosition.position)<followDistance)
        {
            chasing = true;
            rb.linearDamping = 3.0f;
        }
        else
        {
            chasing = false;
            rb.linearDamping = 1.25f;
        }
    }
}