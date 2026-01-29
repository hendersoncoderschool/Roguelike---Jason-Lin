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
    public EnergyMeter energyMeter;
    public GameObject playerBullet;
    public TextMeshProUGUI healthDisplay;
    public GameObject shopPanel;

    //Upgrades
    public int totalSpeedUpgrades;
    public int totalFirerateUpgrades;
    public int totalMaxHealthUpgrades;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        exhausted = false;
        StartCoroutine(Firerate());
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 forceDirection = new Vector2(horizontal, vertical).normalized;

        if (energy>0f)
        {
            energy -= rb.linearVelocity.magnitude * (movementEnergyCost/moveSpeed) * Time.deltaTime;
        }
        if (energy < 1f) exhausted = true;
        else if (energy > 50f) exhausted = false;
        if (energy>=0.1f&&!exhausted)
        {
            rb.AddForce(forceDirection * Time.deltaTime * moveSpeed, ForceMode2D.Force);
        }
        if(energy>maxEnergy)
        {
            energy = maxEnergy;
        }
        energy += rechargeEnergy*Time.deltaTime;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Time.timeScale==1)
        {
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            transform.up = direction;
        }
        healthDisplay.text = health.ToString()+"/"+maxHealth.ToString();

        if(Input.GetKeyDown(KeyCode.Space))
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
            //Time.timeScale == 1 ? Time.timeScale = 0 : Time.timeScale = 1;
        }    
    }
    IEnumerator Firerate()
    {
        while(true)
        {
            if (Input.GetMouseButton(0) && energy >= 0.1 && !exhausted)
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
}