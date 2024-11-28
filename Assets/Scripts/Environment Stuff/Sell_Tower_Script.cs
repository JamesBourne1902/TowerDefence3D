using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sell_Tower_Script : MonoBehaviour
{
    public Player_Stats_Script player;
    public Upgrade_UI_Script upgrader;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats_Script>();
        upgrader = gameObject.GetComponentInParent<Upgrade_UI_Script>();
    }

    public void sellTower()
    {
        player.cashChange(upgrader.specificTower.GetComponent<Tower_Stat_Script>().sellValue);
        upgrader.specificTower.GetComponent<Tower_Stat_Script>().towerSlot.SetActive(true);
        Destroy(upgrader.specificTower);
        Menu_Manager_Script.instance.closeTowerMenus();
    }
}
