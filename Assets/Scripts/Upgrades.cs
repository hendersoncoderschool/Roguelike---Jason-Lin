using UnityEngine;
using TMPro;
public class Upgrades : MonoBehaviour
{
    public Player player;
    public RerollUpgrades rerollScript;
    public TextMeshProUGUI costText;
    public float baseCost;
    public float finalCost;
    public string upgradeType;
    
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rerollScript = GameObject.Find("Reroll").GetComponent<RerollUpgrades>();
    }
    void Update()
    {
        //Set Upgrade Cost & Cost Text
        switch (upgradeType)
        {
            case "Speed":
                finalCost = baseCost * (player.totalSpeedUpgrades+1);
                costText.text = finalCost.ToString() + " Coins";
                break;

            case "Firerate":
                finalCost = baseCost * (player.totalFirerateUpgrades + 1);
                costText.text = finalCost.ToString() + " Coins";
                break;

            case "Max Health":
                finalCost = baseCost * (player.totalMaxHealthUpgrades + 1);
                costText.text = finalCost.ToString() + " Coins";
                break;

            case "Heal 15":
                finalCost = baseCost * (player.totalHeals + 1);
                costText.text = finalCost.ToString() + " Coins";
                break;

            case "Max Energy":
                finalCost = baseCost * (player.totalMaxEnergyUpgrades + 1);
                costText.text = finalCost.ToString() + " Coins";
                break;

            case "Energy Recharge":
                finalCost = baseCost * (player.totalEnergyRechargeUpgrades + 1);
                costText.text = finalCost.ToString() + " Coins";
                break;
        }
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
        if (player.totalCoins>=finalCost)
        {
            player.totalCoins -= finalCost;
            player.moveSpeed = Mathf.Log(player.totalSpeedUpgrades + 6) * 400 + 200;
            player.totalSpeedUpgrades += 1;
            CallReroll();
        }
    }
    public void FirerateUpgrade()
    {
        if (player.totalCoins >= finalCost)
        {
            player.totalCoins -= finalCost;
            player.firerate *= 0.8f;
            player.totalFirerateUpgrades += 1;
            CallReroll();
        }
    }
    public void MaxHealthUpgrade()
    {
        if (player.totalCoins >= finalCost)
        {
            player.totalCoins -= finalCost;
            player.maxHealth += 5;
            player.health += 5;
            player.totalMaxHealthUpgrades += 1;
            CallReroll();
        }
    }
    public void Heal15Health()
    {
        if (player.totalCoins>=finalCost)
        {
            player.totalCoins -= finalCost;
            player.health += 15;
            player.totalHeals += 1;
            CallReroll();
        }
    }
    public void MaxEnergyUpgrade()
    {
        if (player.totalCoins>=finalCost)
        {
            player.totalCoins -= finalCost;
            player.maxEnergy += 20;
            player.totalMaxEnergyUpgrades += 1;
            CallReroll();
        }
    }
    public void EnergyRechargeUpgrade()
    {
        if (player.totalCoins>=finalCost)
        {
            player.totalCoins -= finalCost;
            player.rechargeEnergy += 5;
            player.totalEnergyRechargeUpgrades += 1;
            CallReroll();
        }
    }
}