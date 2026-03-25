using UnityEngine;
using System.Collections;
public class TunnelerExplosionDamage : MonoBehaviour
{
    public GameObject player;
    public bool hitPlayer;
    public Renderer renderer;
    void Start()
    {
        player = GameObject.Find("Player");
        hitPlayer = false;
        renderer = GetComponent<Renderer>();
        StartCoroutine(FadeAway());
    }
    IEnumerator FadeAway()
    {
        while (true)
        {
            Color temp = renderer.material.color;
            temp.a = 255f;
            temp.a -= 50f * Time.deltaTime;
            renderer.material.color = temp;
            if (temp.a <= 0f)
            {
                Destroy(gameObject);
            }
            yield return null;
            //fix
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