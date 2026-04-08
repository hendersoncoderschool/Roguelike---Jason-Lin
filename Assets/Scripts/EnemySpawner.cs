using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> AllEnemies;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(FirstWaves());
    }
    IEnumerator FirstWaves()
    {
        yield return new WaitForSeconds(1f);
        SpawnEnemy();
        while (true)
        {
            yield return new WaitForSeconds(5f);
            SpawnEnemy();
        }
    }
    /*IEnumerator RandomWaves()
    {

    }*/
    void SpawnEnemy()
    {
        GameObject newEnemy=Instantiate(AllEnemies[0], player.transform.position/*new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f))*/, transform.rotation);
        if (Vector2.Distance(newEnemy.transform.position,player.transform.position)<2.5f)
        {
            newEnemy.transform.up = (new Vector3(0, 0, 0) - newEnemy.transform.position).normalized;
            print(newEnemy.transform.up);
            newEnemy.transform.Translate(newEnemy.transform.up * 3f);
            //fix directions
        }
    }
}