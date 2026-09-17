using UnityEngine;
public class TickChase : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public Rigidbody2D rb;
    public bool isAttached;
    void Start()
    {
        //Variables
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Move only if tick is not attached
        if (!isAttached)
        {
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        //Attach to player if tick is close enough
        float playerDistance = Vector2.Distance((Vector2)gameObject.transform.position, player.transform.position);
        if (playerDistance <=1 && !isAttached)
        {
            AttachToPlayer();
        }
    }
    public void AttachToPlayer()
    {
        //Disable player collisions
        rb.simulated = false;
        //Set parent, position, and rotation
        transform.SetParent(player.transform);
        transform.localRotation = Quaternion.identity;
        float randomX = Random.Range(-0.25f, 0.25f);
        float randomY = Random.Range(-0.25f, 0.25f);
        transform.localPosition = new Vector3(randomX, randomY, 0f);
        isAttached = true;
    }
}