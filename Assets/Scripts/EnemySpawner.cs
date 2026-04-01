using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> AllEnemies;
    void Start()
    {
        StartCoroutine(FirstWaves());
    }
    void Update()
    {
        
    }
    IEnumerator FirstWaves()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(AllEnemies[0], new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f)), transform.rotation);
        //fix speed on chasing enemies

    }
    /*IEnumerator RandomWaves()
    {

    }*/
}