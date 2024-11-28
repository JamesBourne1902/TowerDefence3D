using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Tower_Script : MonoBehaviour
{
    public Single_Target_Script inRange;
    public Tower_Stat_Script stats;
    public GameObject turret;

    public bool canShoot = true;

    void Start()
    {
        inRange = gameObject.GetComponentInChildren<Single_Target_Script>();
        stats = gameObject.GetComponent<Tower_Stat_Script>();

        transform.position += new Vector3(0, 3.95f, 0);
    }

    // attempts to shoot and enemy and if successful, looks at that enemy and starts a cooldown
    public void shoot()
    {
        inRange.shootFirst(stats.damage);

        if (inRange.enemyWasDamaged)
        {
            lookAtEnemy();
            TryToapplyBurn();
            tryToExplode();
            inRange.enemyWasDamaged = false;
            canShoot = false;
            Invoke("setCanShoot", stats.shotDelay);
        }
    }

    // Changes the direction of the turret to look at the enemy it shoots
    private void lookAtEnemy()
    {
        Vector3 direction = inRange.targetPosition - turret.transform.position;
        direction.Normalize();
        turret.transform.forward = direction;
    }

    // enables the turret to shoot again
    private void setCanShoot()
    {
        canShoot = true;
    }

    private void TryToapplyBurn()
    {
        if (stats.upgradeNumber[1] == 3)
        {
            inRange.LatestTarget.GetComponent<Stats_Script>().startBurning();
        }
    }

    private void tryToExplode()
    {
        if (stats.upgradeNumber[1] == 4)
        {
            inRange.LatestTarget.GetComponent<Stats_Script>().explode();
        }
    }
}
