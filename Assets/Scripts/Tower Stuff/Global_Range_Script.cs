using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Global_Range_Script : MonoBehaviour
{
    public Logic_Script logic;

    public Transform parent;
    public GameObject strongest;
    public GameObject first;
    public GameObject closest;

    public bool enemyWasHit = false;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic_Script>();
        parent = gameObject.GetComponentInParent<Transform>();
    }

    // finds the enemy that is furthest along the track and assigns it to the 'first' variable
    private void setFirst()
    {
        float distance = 0;

        try
        {
            foreach (GameObject enemy in logic.activeEnemies)
            {
                if (enemy.GetComponent<Stats_Script>().distanceTravelled > distance)
                {
                    first = enemy;
                    distance = enemy.GetComponent<Stats_Script>().distanceTravelled;
                }
            }
        }
        catch
        {
            setFirst();
        }
    }

    private void setStrongest()
    {

    }

    private void setClosest()
    {

    }

    // has the tower shoot the 'first' enemy for the damage input to the function
    public void shootFirst(int damage)
    {
        setFirst();
        if (first != null)
        {
            enemyWasHit = true;
            first.GetComponent<Stats_Script>().takeDamage(damage);
        }
    }

    public void shootStrongest()
    {

    }
    public void shootClosest()
    {

    }
}
