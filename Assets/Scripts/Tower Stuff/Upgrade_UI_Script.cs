using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_UI_Script : MonoBehaviour
{
    public Object_Detection_Script detector;

    public GameObject sellButton;
    public GameObject specificTower = null;

    public GameObject P1_U1;
    public GameObject P1_U2;
    public GameObject P1_U3;
    public GameObject P1_U4;
    public GameObject P1_Comp;
    public GameObject P1_Block;
    public GameObject P2_U1;
    public GameObject P2_U2;
    public GameObject P2_U3;
    public GameObject P2_U4;
    public GameObject P2_Comp;
    public GameObject P2_Block;

    private void Start()
    {
        detector = GameObject.FindGameObjectWithTag("Player").GetComponent<Object_Detection_Script>();
    }

    // finds which upgrade a specific tower is on and enables the following upgrade's button
    public void activateUI()
    {
        sellButton.GetComponentInChildren<Text>().text = "Sell: " + specificTower.GetComponent<Tower_Stat_Script>().sellValue;
        enableU1Line();
        enableU2Line();
    }

    // disables all the buttons when the menu is closed
    private void OnDisable()
    {
        P1_U1.SetActive(false);
        P1_U2.SetActive(false);
        P1_U3.SetActive(false);
        P1_U4.SetActive(false);
        P2_U1.SetActive(false);
        P2_U2.SetActive(false);
        P2_U3.SetActive(false);
        P2_U4.SetActive(false);
        P1_Comp.SetActive(false);
        P2_Comp.SetActive(false);
        P1_Block.SetActive(false);
        P2_Block.SetActive(false);
    }

    public void resetButtons()
    {
        P1_U1.SetActive(false);
        P1_U2.SetActive(false);
        P1_U3.SetActive(false);
        P1_U4.SetActive(false);
        P2_U1.SetActive(false);
        P2_U2.SetActive(false);
        P2_U3.SetActive(false);
        P2_U4.SetActive(false);
        P1_Comp.SetActive(false);
        P2_Comp.SetActive(false);
        P1_Block.SetActive(false);
        P2_Block.SetActive(false);

        enableU1Line();
        enableU2Line();
    }

    // enables the correct upgrade button for path 1
    public void enableU1Line()
    {
        int[] temp = specificTower.GetComponent<Tower_Stat_Script>().upgradeNumber;

        if (temp[1] > 2 && temp[0] == 2)
        {
            P1_Block.SetActive(true);
        }
        else if (temp[0] == 0)
        {
            P1_U1.SetActive(true);
        }
        else if (temp[0] == 1)
        {
            P1_U2.SetActive(true);
        }
        else if (temp[0] == 2)
        {
            P1_U3.SetActive(true);
        }
        else if (temp[0] == 3)
        {
            P1_U4.SetActive(true);
        }
        else if (temp[0] == 4)
        {
            P1_Comp.SetActive(true);
        }
    }

    // enables the correct upgrade button for path 2
    public void enableU2Line()
    {
        int[] temp = specificTower.GetComponent<Tower_Stat_Script>().upgradeNumber;

        if (temp[0] > 2 && temp[1] == 2)
        {
            P2_Block.SetActive(true);
        }
        if (temp[1] == 0)
        {
            P2_U1.SetActive(true);
        }
        else if (temp[1] == 1)
        {
            P2_U2.SetActive(true);
        }
        else if (temp[1] == 2)
        {
            P2_U3.SetActive(true);
        }
        else if (temp[1] == 3)
        {
            P2_U4.SetActive(true);
        }
        else if (temp[1] == 4)
        {
            P2_Comp.SetActive(true);
        }
    }
}
