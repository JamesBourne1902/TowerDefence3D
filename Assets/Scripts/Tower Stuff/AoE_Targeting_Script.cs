using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class AoE_Targeting_Script : MonoBehaviour
{
    public Logic_Script logic;
    public Tower_Stat_Script stats;

    public Transform parent;
    public bool enemyWasDamaged = false;
    public Vector3 distance;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic_Script>();
        stats = gameObject.GetComponentInParent<Tower_Stat_Script>();
        parent = transform.parent;
    }

    // damages each enemy in the range of the tower this is attached to
    public void DamageEnemy(int damage)
    {
        try
        {

            foreach (GameObject enemy in logic.activeEnemies)
            {
                if (findDistance(enemy))
                {
                    enemy.GetComponent<Stats_Script>().takeDamage(damage);
                    enemyWasDamaged = true;
                }
            }
        }
        catch
        {
            DamageEnemy(damage);
        }
    }

    // finds the distance between the tower and the enemy
    private bool findDistance(GameObject enemy)
    {
        distance = parent.InverseTransformPoint(enemy.transform.position);
        if (Mathf.Clamp(distance.x, stats.range.x, 0) == distance.x && Mathf.Clamp(distance.z, stats.range.z * -1, stats.range.z) == distance.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
