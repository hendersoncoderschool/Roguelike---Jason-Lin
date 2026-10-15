using UnityEngine;
using System.Collections;
public class TickChase : MonoBehaviour
{
    public float speed;
    public float randomX;
    public float randomY;
    public float speedMultiplier;
    public GameObject player;
    public Player playerScript;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public bool isAttached;
    void Start()
    {
        //Variables
        player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //Move only if tick is not already attached and maxTickCount has not been reached
        if (!isAttached)
        {
            if(playerScript.tickCount < playerScript.maxTickCount)
            {
                Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
        //Attach to player if tick is close enough
        float playerDistance = Vector2.Distance((Vector2)gameObject.transform.position, player.transform.position);
        if (playerDistance <=1 && !isAttached && playerScript.tickCount<playerScript.maxTickCount)
        {
            StartCoroutine(AttachToPlayer());
        }
    }
    public IEnumerator AttachToPlayer()
    {
        isAttached = true;
        //Add tick to a list on the player
        playerScript.tickCount++;
        playerScript.tickList.Add(gameObject.GetComponent<TickChase>());
        //Generate new point
        randomX = Random.Range(-0.25f, 0.25f);
        randomY = Random.Range(-0.25f, 0.25f);
        //Make new empty object on player
        GameObject TickPoint = new GameObject("Tick Point");
        TickPoint.transform.SetParent(player.transform);
        TickPoint.transform.localPosition = new Vector3(randomX, randomY, 0f);
        //Disable tick collisions
        rb.simulated = false;
        //Move tick to the empty object
        speedMultiplier = 1.5f;
        while (true)
        {
            if(Vector2.Distance(TickPoint.transform.position, transform.position) <= 0.08f)
            {
                break;
            }
            Vector2 direction = ((Vector2)TickPoint.transform.position - (Vector2)transform.position).normalized;
            transform.Translate(direction * speed * speedMultiplier * Time.deltaTime);
            speedMultiplier += 25 * Time.deltaTime;
            yield return null;
        }
        //Set parent, position, and rotation
        transform.SetParent(player.transform);
        transform.localRotation = Quaternion.identity;
        transform.localPosition = TickPoint.transform.localPosition;
        Destroy(TickPoint);
    }
    public IEnumerator TickJumpOff()
    {
        //Remove this tick from list
        playerScript.tickList.RemoveAt(0);
        //Set lower alpha
        Color currentColor = spriteRenderer.color;
        spriteRenderer.color = new Color(
            currentColor.r,
            currentColor.g,
            currentColor.b,
            0.5f);
        //Set parent to nothing
        transform.SetParent(null);
        //Set jumping off variables
        float jumpOffSpeed = 6f;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        //Jump off player while slowing down
        while(true)
        {
            //Move in random direction and slow down
            transform.Translate(randomDirection * jumpOffSpeed * Time.deltaTime);
            jumpOffSpeed -= 8 * Time.deltaTime;
            //Break if speed <= 0
            if(jumpOffSpeed<=0)
            {
                break;
            }
            //Prevents going through walls
            Vector2 currentPosition = transform.position;
            //X position
            switch (transform.position.x)
            {
                case >= 0:
                    currentPosition.x = Mathf.Min(transform.position.x, 7.9f);
                    break;
                case < 0:
                    currentPosition.x = Mathf.Max(transform.position.x, -7.9f);
                    break;
            }
            //Y position
            switch (transform.position.y)
            {
                case >= 0:
                    currentPosition.y = Mathf.Min(transform.position.y, 2.9f);
                    break;
                case < 0:
                    currentPosition.y = Mathf.Max(transform.position.y, -3.9f);
                    break;
            }
            transform.position = currentPosition;
            yield return null;
        }
        //Reset rotation and rb
        transform.localRotation = Quaternion.identity;
        rb.simulated = true;
        //Stun
        yield return new WaitForSeconds(1.5f);
        //Set normal alpha
        spriteRenderer.color = new Color(
            currentColor.r,
            currentColor.g,
            currentColor.b,
            1f);
        playerScript.tickCount--;
        isAttached = false;
    }
}