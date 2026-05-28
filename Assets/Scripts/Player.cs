using UnityEngine;
using TMPro;
using System.Collections;
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float energy;
    public float maxEnergy;
    public float rechargeEnergy;
    public float movementEnergyCost;
    public float health;
    public float maxHealth;
    public float firerate;
    public bool exhausted;
    public float totalCoins;
    public EnergyMeter energyMeter;
    public GameObject playerBullet;
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI coinDisplay;
    public GameObject shopPanel;
    //max energy and starting energy is 200

    //Upgrades
    public int totalSpeedUpgrades;
    public int totalFirerateUpgrades;
    public int totalMaxHealthUpgrades;
    public int totalHeals;
    public int totalMaxEnergyUpgrades;
    public int totalEnergyRechargeUpgrades;

    //Debug
    public int targetFPS;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        exhausted = false;
        totalCoins = 0;
        StartCoroutine(Firerate());
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 forceDirection = new Vector2(horizontal, vertical).normalized;

        //Energy Calculations

        //Movement Energy Cost
        if (energy>0f)
        {
            energy -= rb.linearVelocity.magnitude * (movementEnergyCost/moveSpeed) * Time.deltaTime;
        }
        //Exhausted
        if (energy < 1f && !exhausted)
        {
            exhausted = true;
            StartCoroutine(ExhaustedTimer());
        }
        if (energy>=0.1f&&!exhausted)
        {
            rb.AddForce(forceDirection * Time.deltaTime * moveSpeed, ForceMode2D.Force);
        }
        //Energy Cap
        if(energy>maxEnergy)
        {
            energy = maxEnergy;
        }
        //Energy Recharge
        energy += rechargeEnergy*Time.deltaTime;

        //Aiming
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Time.timeScale==1)
        {
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            transform.up = direction;
        }

        //Health
        health = Mathf.Min(health, maxHealth);
        healthDisplay.text = health.ToString()+"/"+maxHealth.ToString();

        //Coins
        coinDisplay.text = "Coins: " + totalCoins.ToString();

        //Shop
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shopPanel.SetActive(!shopPanel.activeInHierarchy);
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }    
    }
    IEnumerator ExhaustedTimer()
    {
        //Waits x seconds if exhausted
        yield return new WaitForSeconds(1.25f);
        exhausted = false;
    }
    IEnumerator Firerate()
    {
        while(true)
        {
            if (Input.GetMouseButton(0) && energy >= 0.1 && !exhausted &&  Time.timeScale>0)
            {
                GameObject newBullet = Instantiate(playerBullet, transform.position, transform.rotation);
                energyMeter.t = 0.0f;
                energy -= 83f * firerate;
                if (energy < 0)
                {
                    energy = 0;
                }
                yield return new WaitForSeconds(firerate);
            }
            yield return null;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet"))
        {
            health -= 1; 
        }
    }
    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            totalCoins++;
            Destroy(col.gameObject);
        }
    }*/
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }
}