using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class RerollUpgrades : MonoBehaviour
{
    public Player player;
    public EnemySpawner enemySpawnerScript;
    public TextMeshProUGUI costText;
    public GameObject upgradeSpawnpoint1;
    public GameObject upgradeSpawnpoint2;
    public GameObject upgradeSpawnpoint3;

    public List<GameObject> upgradeButtons;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        enemySpawnerScript = GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawner>();
        upgradeSpawnpoint1 = GameObject.Find("UpgradeSpawnpoint1");
        upgradeSpawnpoint2 = GameObject.Find("UpgradeSpawnpoint2");
        upgradeSpawnpoint3 = GameObject.Find("UpgradeSpawnpoint3");
    }
    void Update()
    {
        costText.text = player.rerollFinalCost + "Coins";
    }
    public void RerollAll()
    {
        if(player.totalCoins>=player.rerollFinalCost)
        {
            player.totalCoins -= player.rerollFinalCost;
            Reroll1();
            Reroll2();
            Reroll3();
            player.totalRerolls += 1;
            player.rerollFinalCost = player.rerollBaseCost + player.totalRerolls;
            player.UpdateRerollCost();
        }
    }
    public void Reroll1()
    {
        Destroy(upgradeSpawnpoint1.transform.GetChild(0).gameObject);
        Instantiate(upgradeButtons[Random.Range(0,upgradeButtons.Count)], upgradeSpawnpoint1.transform);
    }
    public void Reroll2()
    {
        Destroy(upgradeSpawnpoint2.transform.GetChild(0).gameObject);
        Instantiate(upgradeButtons[Random.Range(0, upgradeButtons.Count)], upgradeSpawnpoint2.transform);
    }
    public void Reroll3()
    {
        Destroy(upgradeSpawnpoint3.transform.GetChild(0).gameObject);
        Instantiate(upgradeButtons[Random.Range(0, upgradeButtons.Count)], upgradeSpawnpoint3.transform);
    }
}