using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager_Script : MonoBehaviour
{
    public static Menu_Manager_Script instance;

    public Object_Detection_Script detector;

    public GameObject winMenu;
    public GameObject deathMenu;
    public GameObject pauseMenu;
    public bool inPauseMenu = false;
    public bool deadOrWon = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        detector = GameObject.FindGameObjectWithTag("Player").GetComponent<Object_Detection_Script>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !deadOrWon)
        {
            if (!inPauseMenu && !detector.inBuyMenu)
            {
                openPauseMenu();
            }
            else
            {
                closeTowerMenus();
                closePauseMenu();
            }
        }
    }

    // opens the pause menu and enables the mouse to be used.
    private void openPauseMenu()
    {
        Time.timeScale = 0;
        detector.EnableMouse();
        pauseMenu.SetActive(true);
        inPauseMenu = true;
    }

    // closes the pause menu and disables the mouse.
    private void closePauseMenu()
    {
        Time.timeScale = 1;
        detector.DisableMouse();
        pauseMenu.SetActive(false);
        inPauseMenu = false;
    }

    // closes all tower-related menus
    public void closeTowerMenus()
    {
        if (detector.currentlyOpen != null)
        {
            detector.currentlyOpen.SetActive(false);
        }
        detector.upgradeUI.SetActive(false);
        detector.TowerButtons.SetActive(false);
        detector.inBuyMenu = false;
        detector.DisableMouse();
    }

    public void openDeathMenu()
    {
        deadOrWon = true;
        detector.EnableMouse();
        deathMenu.SetActive(true);
        inPauseMenu = true;
    }

    public void openWinMenu()
    {
        deadOrWon = true;
        detector.EnableMouse();
        winMenu.SetActive(true);
        inPauseMenu = true;
    }
}
