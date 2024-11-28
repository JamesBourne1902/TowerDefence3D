using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Upgrades_Script : MonoBehaviour
{
    public Upgrade_UI_Script UI;
    public Player_Stats_Script PlayerStats;

    public Material sphereU1_1Colour;
    public Material sphereU1_2Colour;
    public Material turretU2_1Colour;
    public Material turretU2_2Colour;
    private GameObject tower;


    void Start()
    {
        UI = gameObject.GetComponent<Upgrade_UI_Script>();
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats_Script>();
    }

    private bool checkMoney(int total, int cost)
    {
        if (cost <= total)
        {
            PlayerStats.cashChange(-1 * cost);
            return true;
        }
        return false;
    }

    public void upgrade1_1() // makes turret tower shoot 25% faster
    {
        tower = UI.specificTower;
        Tower_Stat_Script temp = tower.GetComponent<Tower_Stat_Script>();

        if (checkMoney(PlayerStats.cash, temp.upgd1_1Cost))
        {
            temp.costChange = temp.upgd1_1Cost;
            temp.upgradeNumber[0] = 1;
            temp.shotDelay = 0.75f;

            tower.transform.Find("Roof").gameObject.GetComponent<MeshRenderer>().material = sphereU1_1Colour;
            UI.resetButtons();
        }
    }

    public void upgrade1_2() // makes turret tower shoot 25% faster
    {
        tower = UI.specificTower;
        Tower_Stat_Script temp = tower.GetComponent<Tower_Stat_Script>();

        if (checkMoney(PlayerStats.cash, temp.upgd1_2Cost))
        {
            temp.costChange = temp.upgd1_2Cost;
            temp.upgradeNumber[0] = 2;
            temp.shotDelay = 0.5f;

            tower.transform.Find("Roof").gameObject.GetComponent<MeshRenderer>().material = sphereU1_2Colour;
            UI.resetButtons();
        }
    }

    public void upgrade1_3() // makes turret tower shoot 25% faster
    {
        tower = UI.specificTower;
        Tower_Stat_Script temp = tower.GetComponent<Tower_Stat_Script>();

        if (checkMoney(PlayerStats.cash, temp.upgd1_3Cost))
        {
            temp.costChange = temp.upgd1_3Cost;
            temp.upgradeNumber[0] = 3;
            temp.shotDelay = 0.25f;

            UI.resetButtons();
        }
    }

    public void upgrade1_4() // makes turret tower shoot 25% faster
    {
        tower = UI.specificTower;
        Tower_Stat_Script temp = tower.GetComponent<Tower_Stat_Script>();

        if (checkMoney(PlayerStats.cash, temp.upgd1_4Cost))
        {
            temp.costChange = temp.upgd1_4Cost;
            temp.upgradeNumber[0] = 4;
            temp.shotDelay = 0.1f;

            UI.resetButtons();
        }
    }

    public void upgrade2_1()
    {
        tower = UI.specificTower;
        Tower_Stat_Script temp = tower.GetComponent<Tower_Stat_Script>();

        if (checkMoney(PlayerStats.cash, temp.upgd2_1Cost))
        {
            temp.costChange = temp.upgd2_1Cost;
            temp.upgradeNumber[1] = 1;
            temp.damage *= 2;

            tower.transform.Find("Base").gameObject.GetComponent<MeshRenderer>().material = turretU2_1Colour;
            UI.resetButtons();
        }
    }

    public void upgrade2_2()
    {
        tower = UI.specificTower;
        Tower_Stat_Script temp = tower.GetComponent<Tower_Stat_Script>();

        if (checkMoney(PlayerStats.cash, temp.upgd2_2Cost))
        {
            temp.costChange = temp.upgd2_2Cost;
            temp.upgradeNumber[1] = 2;
            temp.damage *= 2;

            tower.transform.Find("Base").gameObject.GetComponent<MeshRenderer>().material = turretU2_2Colour;
            UI.resetButtons();
        }
    }

    public void upgrade2_3()
    {
        tower = UI.specificTower;
        Tower_Stat_Script temp = tower.GetComponent<Tower_Stat_Script>();

        if (checkMoney(PlayerStats.cash, temp.upgd2_3Cost))
        {
            temp.costChange = temp.upgd2_3Cost;
            temp.upgradeNumber[1] = 3;
            temp.damage *= 2;

            UI.resetButtons();
        }
    }

    public void upgrade2_4()
    {
        tower = UI.specificTower;
        Tower_Stat_Script temp = tower.GetComponent<Tower_Stat_Script>();

        if (checkMoney(PlayerStats.cash, temp.upgd2_4Cost))
        {
            temp.costChange = temp.upgd2_4Cost;
            temp.upgradeNumber[1] = 4;
            temp.damage *= 2;

            UI.resetButtons();
        }
    }
}
