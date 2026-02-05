using UnityEngine;
public class BlockerChase : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(transform.forward, rotationSpeed * Time.deltaTime);
        //50% chance to rotate the other direction
    }
}