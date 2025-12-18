using UnityEngine;
using System.Collections;
public class Dash : MonoBehaviour
{
    public float speed;
    void Start()
    {
        StartCoroutine(Dashrate());
    }
    IEnumerator Dashrate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
        }
    }
}