using UnityEngine;
using System.Collections;
public class TunnelerChase : MonoBehaviour
{
    public float speed;
    public float firerate;
    Rigidbody2D rb;
    //public Renderer tunnelerBodyRenderer;
    public Animator tunnelerBodyAnimator;
    Transform player;
    GameObject tunnelerBody;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        tunnelerBody = transform.GetChild(0).gameObject;
        tunnelerBodyAnimator = tunnelerBody.GetComponent<Animator>();
        //tunnelerBodyRenderer = tunnelerBody.GetComponent<Renderer>();
        StartCoroutine(Movement());
    }
    IEnumerator Movement()
    {
        while(true)
        {
            tunnelerBody.SetActive(false);
            for(int i=0; i<1; i++)
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
            yield return new WaitForSeconds(0.65f);
            tunnelerBody.SetActive(true);
            tunnelerBodyAnimator.SetBool("ActivateIdle 0", true);
            print("idle");
            yield return new WaitForSeconds(0.3f);
            tunnelerBodyAnimator.SetBool("ActivateIdle 0", false);
            tunnelerBodyAnimator.SetBool("FlashRed 0",true);
            print("flashred");
            yield return new WaitForSeconds(1.5f);
            tunnelerBodyAnimator.SetBool("FlashRed 0", false);
            tunnelerBodyAnimator.SetBool("ActivateIdle 0", true);
            print("idle");
        }
    }
}