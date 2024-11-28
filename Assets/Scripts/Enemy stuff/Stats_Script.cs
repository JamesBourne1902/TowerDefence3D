using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats_Script : MonoBehaviour
{
    public Logic_Script logic;
    public Player_Stats_Script player;

    public float distanceTravelled;
    public float speed;
    public int health;
    private int totalHealth;
    public bool isArmored;
    public bool isJetpacked;
    public bool isFire;
    public bool isIce;
    public bool isElectric;
    public bool isEarth;

    public GameObject bloodEffect;
    public GameObject healthBar;
    public GameObject healthText;
    public GameObject cash;

    public bool isBurning = false;
    public int burnMultiplier;
    public GameObject explosion;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic_Script>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats_Script>();
        cash = player.money;

        totalHealth = health;
        healthBar.GetComponent<Image>().color = Color.green;
    }


    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
    }

    public void takeDamage(int damageDealt) // Causes the enemy this is attached to to take damage
    {
        health -= damageDealt;
        healthText.GetComponent<Text>().text = health.ToString() + "/" + totalHealth;
        healthBarColorChange();
        OnDamageColourIndicator();
    }

    private void die() // kills the enemy this is attached to and ups the players money
    {
        logic.activeEnemies.Remove(gameObject);
        player.cash += 10;
        cash.GetComponent<Text>().text = "£" + player.cash;
        Destroy(gameObject);
    }

    private void healthBarColorChange() // changes the health Bar colour and dies if health < 0
    {
        if (health <= totalHealth / 2 && health > totalHealth / 8)
        {
            healthBar.GetComponent<Image>().color = Color.yellow;
        }
        else if (health <= totalHealth / 8 && health > 0)
        {
            healthBar.GetComponent<Image>().color = Color.red;
        }
        else if (health <= 0)
        {
            die();
        }
    }

    public void startBurning()
    {
        if (!isFire && !isBurning)
        {
            StartCoroutine(takeBurnDamage());
            isBurning = true;
        }
    }

    // Causes the enemy to take burn damage every 2 seconds for 20 seconds
    private IEnumerator takeBurnDamage()
    {
        int index = 0;

        while (index < 10)
        {
            takeDamage(5*burnMultiplier);
            index += 1;
            yield return new WaitForSeconds(2);
        }

        isBurning = false;
        burnMultiplier = 1;
        print(burnMultiplier);
    }

    public void explode()
    {
        Instantiate(explosion, transform.position, Random.rotation);
    }

    private void OnDamageColourIndicator()
    {
        Instantiate(bloodEffect, transform.position, transform.rotation);
    }
}
