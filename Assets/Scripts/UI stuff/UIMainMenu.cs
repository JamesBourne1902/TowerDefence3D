using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject mapMenu;

    public void openMapMenu()
    {
        mainMenu.SetActive(false);
        mapMenu.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void openMap(string name)
    {
        ScenesManager.instance.loadMap(name);
    }
}
