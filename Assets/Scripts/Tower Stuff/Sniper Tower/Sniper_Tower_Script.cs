using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Tower_Script : MonoBehaviour
{
    public Global_Range_Script fireShot;
    public Tower_Stat_Script stats;

    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        fireShot = gameObject.GetComponentInChildren<Global_Range_Script>();
        stats = gameObject.GetComponent<Tower_Stat_Script>();
        transform.position += new Vector3(0, 9.77f, 0);
    }

    // attempts to shoot an enemy and if successful it starts a cooldown
    void Update()
    {
        if (canShoot)
        {
            try
            {
                fireShot.shootFirst(stats.damage);

                if (fireShot.enemyWasHit)
                {
                    canShoot = false;
                    fireShot.enemyWasHit = false;
                    Invoke("enableShooting", stats.shotDelay);
                }
            }
            catch { }
        }
    }

    // enables the tower to fire again
    private void enableShooting()
    {
        canShoot = true;
    }
}
