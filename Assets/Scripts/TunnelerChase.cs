using UnityEngine;
using System.Collections;
public class TunnelerChase : MonoBehaviour
{
    public float speed;
    public float firerate;
    Rigidbody2D rb;
    public Animator tunnelerBodyAnimator;
    Transform player;
    GameObject tunnelerBody;
    public SpriteRenderer tunnelerBodySpriteRenderer;
    public CircleCollider2D tunnelerBodyCollider;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        tunnelerBody = transform.GetChild(0).gameObject;
        tunnelerBodyAnimator = tunnelerBody.GetComponent<Animator>();
        tunnelerBodySpriteRenderer = tunnelerBody.GetComponent<SpriteRenderer>();
        tunnelerBodyCollider = tunnelerBody.GetComponent<CircleCollider2D>();
        StartCoroutine(Movement());
    }
    IEnumerator Movement()
    {
        while(true)
        {
            tunnelerBodySpriteRenderer.enabled = false;
            tunnelerBodyCollider.enabled = false;
            for (int i=0; i<4; i++)
            {
                float t = 0f;
                while (t < 0.8f)
                {
                    Vector2 direction = (player.position - transform.position).normalized;
                    rb.AddForce(direction * speed);
                    t += Time.deltaTime;
                    yield return null;
                }
                yield return new WaitForSeconds(0.6f);
            }
            yield return new WaitForSeconds(0.70f);
            tunnelerBodySpriteRenderer.enabled = true;
            tunnelerBodyCollider.enabled = true;
            tunnelerBodyAnimator.SetBool("FlashingRed", false);
            yield return new WaitForSeconds(0.3f);
            tunnelerBodyAnimator.SetBool("FlashingRed",true);
            yield return new WaitForSeconds(1f);
            tunnelerBodyAnimator.SetBool("FlashingRed", false);
            yield return new WaitForSeconds(1.2f);
        }
    }
}