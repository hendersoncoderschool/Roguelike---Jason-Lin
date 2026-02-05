using UnityEngine;

public class BulletEnemyChase : MonoBehaviour
{
    public float speed;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position);
        transform.up = direction;
        transform.Translate(Vector2.up * speed * direction.magnitude * Time.deltaTime);
    }
}
