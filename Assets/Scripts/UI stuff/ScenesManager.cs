using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    // allows this script to be accessable from anywhere without needing a reference
    // using ScenesManager.instance
    private void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Map01,
        Map02
    }

    public void loadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    // can load maps from a string input
    public void loadMap(string mapName)
    {
        foreach (Scene scene in Enum.GetValues(typeof(Scene)))
        {
            if (mapName == scene.ToString())
            {
                loadScene(scene);
            }
        }
    }
}
