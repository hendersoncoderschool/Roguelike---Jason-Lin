using UnityEngine;
public class EnemyPlayerCollision : MonoBehaviour
{
    public GameObject player; 
    public Rigidbody2D rb;
    void Start()
    {
        player = GameObject.Find("Player");
        if (rb==null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check if collided with Player
        if (col.gameObject.CompareTag("Player"))
        {
            //Check if the enemy is an ambusher, then do more knockback and damage
            if (gameObject.name.Contains("AmbusherEnemy"))
            {
                rb.AddForce(((Vector2)transform.position - (Vector2)col.transform.position).normalized * 8f, ForceMode2D.Impulse);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(((Vector2)col.transform.position - (Vector2)transform.position).normalized * 6f, ForceMode2D.Impulse);
                col.gameObject.GetComponent<Player>().health -= 2;
            }
            else
            {
                rb.AddForce(((Vector2)transform.position - (Vector2)col.transform.position).normalized * 5f, ForceMode2D.Impulse);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(((Vector2)col.transform.position - (Vector2)transform.position).normalized * 3f, ForceMode2D.Impulse);
                col.gameObject.GetComponent<Player>().health -= 1;
            }
        }
    }
}