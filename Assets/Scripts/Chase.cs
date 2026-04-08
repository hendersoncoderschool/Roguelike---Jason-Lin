using UnityEngine;
public class Chase : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position);
        transform.up = direction;
        float finalSpeed = Mathf.Pow(speed, direction.magnitude - 3) + 0.6f;
        if (finalSpeed > maxSpeed)
        {
            finalSpeed = maxSpeed;
        }
        transform.Translate(Vector2.up * finalSpeed * Time.deltaTime);
    }
}