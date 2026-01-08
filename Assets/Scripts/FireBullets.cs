using UnityEngine;
using System.Collections;
public class FireBullets : MonoBehaviour
{
    public GameObject enemyBullet;
    public float fireRate;
    void Start()
    {
        StartCoroutine(Firerate());
    }
    IEnumerator Firerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            GameObject newBullet = Instantiate(enemyBullet, transform.position, transform.rotation);
        }
    }
}