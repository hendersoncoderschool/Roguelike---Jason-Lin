using UnityEngine;
public class Upgrades : MonoBehaviour
{
    //(1/ln(1.02)x)*10
    public Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); 
    }
    public void SpeedUpgrade()
    {
        player.moveSpeed += 200;
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