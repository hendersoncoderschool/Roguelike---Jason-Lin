using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using System.Linq;
public class EnemySpawner : MonoBehaviour
{
    public int waveNumber;
    public List<GameObject> AllEnemies;
    public Dictionary<GameObject, int> EnemyChances;
    public GameObject player;
    public GameObject ChaseEnemy;
    public GameObject DashEnemy;
    public GameObject BulletEnemy;
    public GameObject BlockerEnemy;
    public GameObject TunnelerEnemy;
    void Start()
    {
        player = GameObject.Find("Player");
        EnemyChances = new Dictionary<GameObject, int>()
        {
            {ChaseEnemy, 100},
            {DashEnemy, 80},
            {BulletEnemy, 50},
            {BlockerEnemy, 50},
            {TunnelerEnemy, 40}
        };
        StartCoroutine(RandomWaves());
    }
    /*IEnumerator FirstWaves()
    {
        yield return new WaitForSeconds(1f);
        SpawnEnemy();
        yield return new WaitForSeconds(5f);
        StartCoroutine(RandomWaves());
    }*/
    IEnumerator RandomWaves()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            SpawnEnemy();
        }        
    }
    void SpawnEnemy()
    {
        var LiveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector2 spawnPosition = new Vector2(0,0);
        for (int i=0;i<5;i++)
        {
            spawnPosition = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f));
            if (Vector2.Distance(player.transform.position, spawnPosition) < 3f)
            {
                print("too close");
                continue;
            }
            foreach (GameObject enemy in LiveEnemies)
            {
                if (Vector2.Distance(enemy.transform.position, spawnPosition) < 0.5f)
                {
                    print("too close");
                    break;
                }
            }
        }
        //Random Enemy Algorithm
        int[] weights = EnemyChances.Values.ToArray();
        int randomWeight = Random.Range(0, weights.Sum());
        GameObject randomEnemy = AllEnemies[0];
        for (int i=0;i<weights.Length;++i)
        {
            randomWeight -= weights[i];
            if (randomWeight < 0)
            {
                randomEnemy = AllEnemies[i];
                break;
            }
        }
        GameObject newEnemy=Instantiate(randomEnemy, spawnPosition, transform.rotation);
        /*
        if (Vector2.Distance(newEnemy.transform.position,player.transform.position)<2.5f)
        {
            newEnemy.transform.up = (new Vector3(0, 0, 0) - newEnemy.transform.position).normalized;
            print(newEnemy.transform.up);
            newEnemy.transform.Translate(newEnemy.transform.up * 3f, Space.World);
        }*/
    }
}