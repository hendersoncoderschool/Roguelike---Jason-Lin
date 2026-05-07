using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using System.Linq;
using TMPro;
public class EnemySpawner : MonoBehaviour
{
    public int waveNumber;
    public float timeToNextEnemy;
    public List<GameObject> AllEnemies;
    public Dictionary<GameObject, int> EnemyChances;
    public GameObject player;
    public TextMeshProUGUI waveText;
    void Start()
    {
        waveText.text = "Wave " + waveNumber.ToString();
        player = GameObject.Find("Player");
        EnemyChances = new Dictionary<GameObject, int>()
        {
            {AllEnemies[0], 100},
            {AllEnemies[1], 70},
            {AllEnemies[2], 0},
            {AllEnemies[3], 0},
            {AllEnemies[4], 0}
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
            //AddEnemies
            if(waveNumber >= 5)
            {
                EnemyChances[AllEnemies[2]] = 50;
            }
            if (waveNumber >= 10)
            {
                EnemyChances[AllEnemies[3]] = 50;
            }
            if (waveNumber >= 15)
            {
                EnemyChances[AllEnemies[4]] = 35;
            }
            //Spawn Enemies
            for (int i = 0; i < 3 + waveNumber / 2; i++)
            {
                yield return new WaitForSeconds(timeToNextEnemy);
                SpawnEnemy();
            }
            var LiveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            while (LiveEnemies.Length > 0)
            {
                LiveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
                yield return new WaitForSeconds(1f);
            }
            waveNumber++;
            waveText.text = "Wave " + waveNumber.ToString();
        }
    }
    void SpawnEnemy()
    {
        //Enemy Spawn Position
        var LiveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector2 spawnPosition = new Vector2(0,0);
        for (int i=0;i<10;i++)
        {
            spawnPosition = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f));
            if (Vector2.Distance(player.transform.position, spawnPosition) < 2.5f)
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
        if(Vector2.Distance(player.transform.position, spawnPosition) < 2.5f)
        {
            newEnemy.transform.up = (new Vector3(0, 0, 0) - newEnemy.transform.position).normalized;
            newEnemy.transform.Translate(newEnemy.transform.up * 3f, Space.World);
        }
    }
}