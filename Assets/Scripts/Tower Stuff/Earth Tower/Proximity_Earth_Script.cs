using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity_Earth_Script : MonoBehaviour
{
    public Earth_Tower_Script tower;

    // Start is called before the first frame update
    void Start()
    {
        tower = gameObject.GetComponentInParent<Earth_Tower_Script>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (tower.canShoot)
        {
            tower.shoot();
        }
    }
}
