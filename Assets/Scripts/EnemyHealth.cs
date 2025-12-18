using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public float health;
    void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 1;
        }
    }
}