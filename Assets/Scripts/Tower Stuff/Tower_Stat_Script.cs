using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Stat_Script : MonoBehaviour
{
    public int cost;
    public int upgd1_1Cost;
    public int upgd1_2Cost;
    public int upgd1_3Cost;
    public int upgd1_4Cost;
    public int upgd2_1Cost;
    public int upgd2_2Cost;
    public int upgd2_3Cost;
    public int upgd2_4Cost;
    public int totalCost;
    public int sellValue;

    public Vector3 range;
    public float shotDelay;
    public int damage;
    public int[] upgradeNumber;

    public GameObject towerSlot;

    public GameObject sellbutton;
    public delegate void variableChangedDelegate();
    public event variableChangedDelegate onVariableChanged;
    public int costChange{                     // when  this variable is edited the below occurs
        get { return totalCost; }              // fetches the totalCost variable so its editable
        set
        {
            totalCost += value;                // increases totalCost by the 'value' input to costChange
            if (onVariableChanged != null)
                onVariableChanged();           // calls all functions subscribed to onVariableChanged
        }
    }

    private void Start()
    {
        totalCost = cost;
        sellValueChange();
        onVariableChanged += sellValueChange; // subscribes sellValueChange to onVaraibleChanged
    }

    public void sellValueChange()
    {
        sellValue = (int)(Mathf.Floor(totalCost*0.75f / 5f) * 5f);
        try
        {
            sellbutton = GameObject.FindGameObjectWithTag("sell button").gameObject;
            sellbutton.GetComponentInChildren<Text>().text = "Sell: " + sellValue.ToString();
        }
        catch { }
    }


}
