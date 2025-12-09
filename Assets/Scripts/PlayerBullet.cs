using UnityEngine;
public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed,ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}