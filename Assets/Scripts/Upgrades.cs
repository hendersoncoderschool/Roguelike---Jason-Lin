using UnityEngine;
public class Upgrades : MonoBehaviour
{
    public Player player;
    public RerollUpgrades rerollScript;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rerollScript = GameObject.Find("Reroll").GetComponent<RerollUpgrades>();
    }
    public void CallReroll()
    {
        if (transform.parent.name == "UpgradeSpawnpoint1")
        {
            rerollScript.Reroll1();
        }
        else if (transform.parent.name == "UpgradeSpawnpoint2")
        {
            rerollScript.Reroll2();
        }
        else
        {
            rerollScript.Reroll3();
        }
    }
    public void SpeedUpgrade()
    {
        player.moveSpeed=Mathf.Log(player.totalSpeedUpgrades+6)*400+200;
        player.totalSpeedUpgrades += 1;
        CallReroll();
    }
    public void FirerateUpgrade()
    {
        player.firerate*=0.8f;
        player.totalFirerateUpgrades += 1;
        CallReroll();
    }
    public void MaxHealthUpgrade()
    {
        player.maxHealth+= 5;
        player.health += 5;
        player.totalMaxHealthUpgrades += 1;
        CallReroll();
    }
}