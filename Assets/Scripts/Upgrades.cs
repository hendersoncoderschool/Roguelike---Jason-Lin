using UnityEngine;
public class Upgrades : MonoBehaviour
{
    public Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); 
    }
    public void SpeedUpgrade()
    {
        player.moveSpeed=Mathf.Log(player.totalSpeedUpgrades+6)*400+250;
    }
    public void FirerateUpgrade()
    {
        player.firerate*=0.8f;
    }
    public void MaxHealthUpgrade()
    {
        player.maxHealth+= 5;
        player.health += 5;
    }
}