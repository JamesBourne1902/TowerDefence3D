using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall_Script : MonoBehaviour
{
    public static Wall_Script instance;
    public Logic_Script logic;

    public GameObject healthText;

    private int health = 200;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic_Script>();
        healthText = GameObject.Find("Health");
        healthText.GetComponent<Text>().text = health.ToString();
    }

    // Causes the wall to take damage if an enemy reaches it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            logic.activeEnemies.Remove(other.gameObject);
            damaged(other.gameObject.GetComponent<Stats_Script>().health);
            Destroy(other.gameObject);
        }
    }

    // applies the damage and updates the UI
    private void damaged(int damage)
    {
        health -= damage;

        if (health > 0)
        {
            healthText.GetComponent<Text>().text = health.ToString();
        }
        else
        {
            healthText.GetComponent<Text>().text = "0";
            Time.timeScale = 0;
            Menu_Manager_Script.instance.openDeathMenu();
        }
    }
}
