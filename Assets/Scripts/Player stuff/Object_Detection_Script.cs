using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Detection_Script : MonoBehaviour
{
    public Tower_Spawner_Script towerSlot;

    private float maxRaycastDist = 25;
    public bool inBuyMenu = false;
    public GameObject crosshair;
    public GameObject TowerButtons;
    public GameObject duller;

    public GameObject upgradeUI;
    public GameObject currentlyOpen;
    public GameObject turretUpgradeUI;
    public GameObject earthUpgradeUI;
    public GameObject sniperUpgradeUI;


    private void Start()
    {
        DisableMouse();
        towerSlot = GameObject.FindGameObjectWithTag("logic").GetComponent<Tower_Spawner_Script>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            detectObject();
        }
    }

    // Uses ray casting to find the object infront of the player
    // if that object is a tower slot it will open the buy menu
    // if that object is a tower it will open the upgade menu
    private void detectObject()
    {
        Vector3 direction = Camera.main.transform.forward;

        Ray ray = new Ray(Camera.main.transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRaycastDist))
        {
            if (hit.collider.gameObject.CompareTag("Tower Spawner"))
            {
                towerSlot.spawnSlot = hit.collider.gameObject;
                openTowerSelectionMenu();
            }

            else if (hit.collider.gameObject.layer == 8)
            {
                openUpgradeMenu(hit.collider.gameObject.transform.root.gameObject);
            }
        }
    }

    // enables the use of the mouse when using the buy menus
    public void EnableMouse()
    {
        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        duller.SetActive(true);
    }

    // disables the mouse so it cant be seen during the game when not needed
    public void DisableMouse()
    {
        crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        duller.SetActive(false);
    }

    // opens the tower buy menu and changes the inBuyMenu bool so you can move while in the menu
    private void openTowerSelectionMenu()
    {
        EnableMouse();
        inBuyMenu = true;
        TowerButtons.SetActive(true);
    }

    // opens the upgrade menu for the tower type selected
    private void openUpgradeMenu(GameObject tower)
    {
        if (tower.name.Replace("(Clone)", "") == "Turret Tower")
        {
            openBuyMenu(turretUpgradeUI, tower);
        }
        else if (tower.name.Replace("(Clone)", "") == "Earth Tower")
        {
            openBuyMenu(earthUpgradeUI, tower);
        }
        else if (tower.name.Replace("(Clone)", "") == "Sniper Tower")
        {
            openBuyMenu(sniperUpgradeUI, tower);
        }
    }

    // opens the upgrade menu for the specific tower input to the function
    private void openBuyMenu(GameObject UI, GameObject tower)
    {
        upgradeUI.SetActive(true);
        currentlyOpen = UI;
        UI.SetActive(true);
        Upgrade_UI_Script temp = UI.GetComponent<Upgrade_UI_Script>();
        temp.specificTower = tower;
        temp.activateUI();
        EnableMouse();
        inBuyMenu = true;
    }
}
