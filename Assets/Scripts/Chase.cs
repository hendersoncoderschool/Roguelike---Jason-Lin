using UnityEngine;
public class Chase : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public Rigidbody2D rb;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position);
        transform.up = direction;
        transform.Translate(Vector2.up * speed * direction.magnitude * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().health -= 1;
            rb.AddForce(((Vector2)transform.position - (Vector2)col.transform.position).normalized * 5f, ForceMode2D.Impulse);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(((Vector2)col.transform.position - (Vector2)transform.position).normalized * 3f, ForceMode2D.Impulse);
        }
    }
}