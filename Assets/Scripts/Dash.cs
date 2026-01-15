using UnityEngine;
using System.Collections;
public class Dash : MonoBehaviour
{
    public Color DashRechargeColor;
    public Renderer renderer;
    public GameObject player;
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        StartCoroutine(StartDash());
    }
    IEnumerator StartDash()
    {
        while (true)
        {
            float t = 0f;
            while(t < 1f)
            {
                renderer.material.color =Color.Lerp(Color.white,Color.red,t);
                t += 0.0015f;
                yield return null;
            }
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position);
            transform.up = direction;
            rb.AddForce(transform.up * speed,ForceMode2D.Impulse);
            t = 0f;
            while (t < 1f)
            {
                renderer.material.color = Color.Lerp(Color.red, Color.white, t);
                t += 0.02f;
                yield return null;
            }
        }
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