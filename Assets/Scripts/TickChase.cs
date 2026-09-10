using UnityEngine;
public class TickChase : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public SpriteRenderer playerObject;
    public Vector2 playerSize;
    public float width;
    public float height;
    public bool isAttached;
    void Start()
    {
        player = GameObject.Find("Player");
        playerObject = player.GetComponent<SpriteRenderer>();
        playerSize =playerObject.bounds.size;
        width = playerSize.x;
        height = playerSize.y;
    }
    void Update()
    {
        if (!isAttached)
        {
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        float playerDistance = Vector2.Distance((Vector2)gameObject.transform.position, player.transform.position);
        if (playerDistance <=1 && !isAttached)
        {
            AttachToPlayer();
        }
    }
    public void AttachToPlayer(/*Transform slot*/)
    {
        Vector3 slotPoint = new Vector3(
            Random.Range(0f,width),
            Random.Range(0f,height),
            0f
            );
        transform.SetParent(player.transform);
        transform.localRotation = Quaternion.identity;
        transform.position = slotPoint;
        isAttached = true;
    }
}