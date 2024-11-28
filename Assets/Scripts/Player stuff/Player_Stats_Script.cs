using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stats_Script : MonoBehaviour
{
    public GameObject money;

    public int cash;

    private void Start()
    {
        money = GameObject.FindGameObjectWithTag("money display");
        cashChange(0);
    }

    public void cashChange(int amount)
    {
        cash += amount;
        money.GetComponent<Text>().text = "£" + cash.ToString();
    }
}
