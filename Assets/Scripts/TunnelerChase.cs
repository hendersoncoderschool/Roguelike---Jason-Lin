using UnityEngine;
using System.Collections;
public class TunnelerChase : MonoBehaviour
{
    public float speed;
    public float firerate;
    Rigidbody2D rb;
    Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    IEnumerator Movement()
    {
        while(true)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.AddForce(direction * speed);
            yield return null;
        }
        //unfinished
    }
}