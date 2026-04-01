using UnityEngine;
using System.Collections;
public class TunnelerExplosionDamage : MonoBehaviour
{
    public GameObject player;
    public bool hitPlayer;
    public Renderer tunnelerRenderer;
    public float fadeSpeed;
    void Start()
    {
        player = GameObject.Find("Player");
        hitPlayer = false;
        tunnelerRenderer = GetComponent<Renderer>();
        StartCoroutine(FadeAway());
    }
    IEnumerator FadeAway()
    {
        while (true)
        {
            Color temp = tunnelerRenderer.material.color;
            temp.a -= fadeSpeed * Time.deltaTime;
            tunnelerRenderer.material.color = temp;
            if (temp.a <= 0f)
            {
                Destroy(gameObject);
            }
            yield return null;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")&&hitPlayer==false)
        {
            col.gameObject.GetComponent<Player>().health -= 1;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(((Vector2)col.transform.position - (Vector2)transform.position).normalized * 6f, ForceMode2D.Impulse);
            hitPlayer = true;
        }
    }
}