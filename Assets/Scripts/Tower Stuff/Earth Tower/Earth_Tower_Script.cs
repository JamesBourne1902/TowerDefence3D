using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Tower_Script : MonoBehaviour
{
    public Logic_Script logic;
    public AoE_Targeting_Script targeting;
    public axel_Script animator;
    public Tower_Stat_Script stats;

    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic_Script>();
        targeting = gameObject.GetComponentInChildren<AoE_Targeting_Script>();
        animator = gameObject.GetComponentInChildren<axel_Script>();
        stats = gameObject.GetComponent<Tower_Stat_Script>();
    }

    public void shoot()
    {
        targeting.DamageEnemy(stats.damage);

        if (targeting.enemyWasDamaged)
        {
            canShoot = false;
            animator.startPlaying();
            targeting.enemyWasDamaged = false;
            Invoke("setCanShoot", stats.shotDelay);
        }
    }

    private void setCanShoot()
    {
        canShoot = true;
    }
}
