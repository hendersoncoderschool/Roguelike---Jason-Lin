using UnityEngine;
using System.Collections;
public class TickChase : MonoBehaviour
{
    public float speed;
    public float randomX;
    public float randomY;
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
            StartCoroutine(AttachToPlayer());
        }
    }
    public IEnumerator AttachToPlayer()
    {
        isAttached = true;
        //Generate new point
        randomX = Random.Range(-0.25f, 0.25f);
        randomY = Random.Range(-0.25f, 0.25f);
        //Make new empty object on player
        GameObject TickPoint = new GameObject("Tick Point");
        TickPoint.transform.SetParent(player.transform);
        TickPoint.transform.localPosition = new Vector3(randomX, randomY, 0f);
        //Disable player collisions
        rb.simulated = false;
        //Move tick to the empty object
        while(true)
        {
            float speedMultiplier = 2;
            if(Vector2.Distance(TickPoint.transform.position, transform.position) <= 0.05f)
            {
                break;
            }
            Vector2 direction = ((Vector2)TickPoint.transform.position - (Vector2)transform.position).normalized;
            transform.Translate(direction * speed * speedMultiplier * Time.deltaTime);
            speedMultiplier += 1 * Time.deltaTime;
            yield return null;
        }
        //Set parent, position, and rotation
        print("done");
        transform.SetParent(player.transform);
        transform.localRotation = Quaternion.identity;
        transform.localPosition = TickPoint.transform.localPosition;
        Destroy(TickPoint);
    }
}