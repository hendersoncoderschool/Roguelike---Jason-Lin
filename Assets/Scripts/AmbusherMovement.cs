using UnityEngine;
public class AmbusherMovement : MonoBehaviour
{
    public float wanderSpeed;
    public float chaseSpeed;
    public float wanderDistance;
    public float playerDistance;
    public float gradualTransparency;
    public GameObject player;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Vector2 wanderPoint;
    void Start()
    {
        //Variables
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        //Choose first wanderPoint
        wanderPoint = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f));
        //Set original transparency
        SetTransparency(0.03f);
    }
    void Update()
    {
        //Check distance from player
        playerDistance= Vector2.Distance((Vector2)gameObject.transform.position, player.transform.position);
        if (playerDistance>2f)
        {
            Wander();
            if(playerDistance>3f)
            {
                //Lowest transparency
                SetTransparency(0.03f);
            }
            else
            {
                //Gradually increase transparency
                gradualTransparency = -1*(playerDistance-3);
                gradualTransparency = Mathf.Max(0.03f, gradualTransparency);
                SetTransparency(gradualTransparency);
            }
        }
        else
        {
            Chase();
            //Full transparency
            SetTransparency(1f);
        }
    }
    void Wander()
    {
        //Check distance from wanderPoint
        wanderDistance = Vector2.Distance((Vector2)gameObject.transform.position, wanderPoint);
        if (wanderDistance>1f)
        {
            //Move towards wanderPoint
            Vector2 direction = (wanderPoint - (Vector2)transform.position).normalized;
            rb.AddForce(direction * wanderSpeed * Time.deltaTime);
        }
        else
        {
            //Choose new wanderPoint
            wanderPoint = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f));
        }
    }
    void Chase()
    {
        //Move towards player
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
        rb.AddForce(direction * chaseSpeed * Time.deltaTime);
    }
    void SetTransparency(float alpha)
    {
        //Set given alpha
        Color currentColor = sprite.color;
        currentColor.a = alpha;
        sprite.color = currentColor;
    }
}