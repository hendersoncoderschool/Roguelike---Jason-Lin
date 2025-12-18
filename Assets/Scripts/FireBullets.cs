using UnityEngine;
using System.Collections;
public class FireBullets : MonoBehaviour
{
    public GameObject enemyBullet; 
    void Start()
    {
        StartCoroutine(Firerate());
    }
    IEnumerator Firerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.2f);
            GameObject newBullet = Instantiate(enemyBullet, transform.position, transform.rotation);
        }
    }
}