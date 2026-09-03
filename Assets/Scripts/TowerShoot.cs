using UnityEngine;
using System.Collections;
public class TowerShoot : MonoBehaviour
{
    public GameObject towerBullet;
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
            GameObject firstNewBullet = Instantiate(towerBullet, transform.position, transform.rotation);
            Quaternion secondBulletRotation = transform.rotation * Quaternion.Euler(180f, 0, 0);
            GameObject secondNewBullet = Instantiate(towerBullet, transform.position, secondBulletRotation);
        }
    }
}