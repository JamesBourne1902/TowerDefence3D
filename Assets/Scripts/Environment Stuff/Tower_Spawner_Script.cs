using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Spawner_Script : MonoBehaviour
{
    public Player_Stats_Script player_stats;

    public GameObject spawnSlot;

    private void Start()
    {
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent <Player_Stats_Script>();
    }

    // Spawns a new tower and assigns the slot it spawned on to that towers stats
    public void spawnTower(GameObject tower)
    {   
        GameObject temp = Instantiate(tower, spawnSlot.transform.position, spawnSlot.transform.rotation);
        Tower_Stat_Script temp2 = temp.GetComponent<Tower_Stat_Script>();

        if (temp2.cost <= player_stats.cash) // checks the player has enough cash to buy the tower
        {
            temp.GetComponent<Tower_Stat_Script>().towerSlot = spawnSlot;
            spawnSlot.SetActive(false);
            player_stats.cashChange(temp2.cost * -1);
            Menu_Manager_Script.instance.closeTowerMenus();
        }
        else
        {
            Destroy(temp);
        }
    }
}
