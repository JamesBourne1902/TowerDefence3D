using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Single_Target_Script : MonoBehaviour
{
    public Logic_Script logic;

    public Transform parent;
    public GameObject strongest;
    public GameObject first;
    public GameObject closest;

    public Vector3 range;
    public Vector3 targetPosition;
    public GameObject LatestTarget;
    public bool enemyWasDamaged = false;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic_Script>();
        parent = gameObject.GetComponentInParent<Transform>();

        range = gameObject.GetComponentInParent<Tower_Stat_Script>().range;
    }

    // finds the enemy that is furthest along the track and assigns it to the 'first' variable
    private void setFirst()
    {
        float distance = 0;

        try
        {
            foreach (GameObject enemy in logic.activeEnemies)
            {
                if (findDistance(enemy) && enemy.GetComponent<Stats_Script>().distanceTravelled > distance)
                {
                    first = enemy;
                    LatestTarget = enemy;
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
            targetPosition = first.transform.position;
            enemyWasDamaged = true;
            first.GetComponent<Stats_Script>().takeDamage(damage);
        }
    }

    public void shootStrongest()
    {

    }
    public void shootClosest()
    {

    }

    // finds the distance between the tower and the enemy
    private bool findDistance(GameObject enemy)
    {
        Vector3 distance = parent.InverseTransformPoint(enemy.transform.position);

        if (Mathf.Clamp(distance.x, range.x, 0) == distance.x && Mathf.Clamp(distance.z, range.z*-1, range.z) == distance.z)
            return true;

        else
        {
            return false;
        }
    }
}
