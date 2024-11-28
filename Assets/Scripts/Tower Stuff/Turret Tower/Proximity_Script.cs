using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Proximity_Script : MonoBehaviour
{
    public Tank_Tower_Script tower;

    // Start is called before the first frame update
    void Start()
    {
        tower = gameObject.GetComponentInParent<Tank_Tower_Script>();
    }

    // attempts to shoot enemies if there is one within range
    public void OnTriggerStay(Collider other)
    {
        if (tower.canShoot)
        {
            tower.shoot();
        }
    }
}
