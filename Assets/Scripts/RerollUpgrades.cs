using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RerollUpgrades : MonoBehaviour
{
    public GameObject upgradeSpawnpoint1;
    public GameObject upgradeSpawnpoint2;
    public GameObject upgradeSpawnpoint3;
    void Start()
    {
        upgradeSpawnpoint1 = GameObject.Find("UpgradeSpawnpoint1");
        upgradeSpawnpoint2 = GameObject.Find("UpgradeSpawnpoint2");
        upgradeSpawnpoint3 = GameObject.Find("UpgradeSpawnpoint3");
    }
    public void RerollAll()
    {
        Reroll1();
        Reroll2();
        Reroll3();
    }
    public void Reroll1()
    {
        //upgradeSpawnpoint1.transform.FindChild
    }
    public void Reroll2()
    {

    }
    public void Reroll3()
    {

    }
}