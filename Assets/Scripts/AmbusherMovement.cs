using UnityEngine;
public class AmbusherMovement : MonoBehaviour
{
    public float wanderSpeed;
    public float chaseSpeed;
    public GameObject player;
    public Rigidbody2D rb;
    public Vector2 wanderPoint;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        Wander();
    }
    void Wander()
    {
        wanderPoint= new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f));
        float distance = Vector2.Distance((Vector2)gameObject.transform.position, wanderPoint);
        /*while (distance>1f)
        {
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position);
            float finalSpeed = Mathf.Pow(speed, direction.magnitude - 3) + 0.6f;
            rb.AddForce(transform.up * finalSpeed * Time.deltaTime * 200f);
        }*/
    }
}