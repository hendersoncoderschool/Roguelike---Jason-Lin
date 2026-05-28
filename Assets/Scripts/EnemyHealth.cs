using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public float baseHealth;
    public float health;
    public float baseValue;
    public float value;
    public GameObject CoinPrefab;
    void Update()
    {
        if (health <= 0f)
        {
            for(int i = 0; i < value; i++)
            {
                Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            }
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