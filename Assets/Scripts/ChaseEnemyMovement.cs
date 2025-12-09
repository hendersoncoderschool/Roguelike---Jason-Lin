using UnityEngine;
public class ChaseEnemyMovement : MonoBehaviour
{
    public float speed;
    public float health;
    public GameObject player;
    public Rigidbody2D rb;
    void Start()
    {
        player = GameObject.Find("Player");
        health = 2;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position);
        transform.up = direction;
        transform.Translate(Vector2.up * speed * direction.magnitude * Time.deltaTime);
        if(health<=0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerMovement>().health -= 1;
            rb.AddForce(-(Vector2)player.transform.position-(Vector2)transform.position);
        }
        else if(col.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 1;
        }
    }
}