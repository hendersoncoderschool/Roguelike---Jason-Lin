using UnityEngine;
using System.Collections;
public class Dash : MonoBehaviour
{
    public Color DashRechargeColor;
    public Renderer renderer;
    public GameObject player;
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        StartCoroutine(StartDash());
    }
    IEnumerator StartDash()
    {
        while (true)
        {
            float t = 0f;
            while(t < 1f)
            {
                //add Time.deltaTime
                while(Time.timeScale==0)
                {
                    yield return null;
                }
                renderer.material.color =Color.Lerp(Color.white,Color.red,t);
                t += 0.8f*Time.deltaTime;
                yield return null;
            }
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position);
            transform.up = direction;
            rb.AddForce(transform.up * speed,ForceMode2D.Impulse);
            t = 0f;
            while (t < 1f)
            {
                while (Time.timeScale == 0)
                {
                       yield return null;
                }
                renderer.material.color = Color.Lerp(Color.red, Color.white, t);
                t += 8f*Time.deltaTime;
                yield return null;
            }
        }
    }
}