using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Spawner_Script spawner;
    public GameObject autoplayButton;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner_Script>();
    }

    public void backToMain()
    {
        ScenesManager.instance.loadMainMenu();
    }

    public void AutoplayChanger()
    {
        if (spawner.autoPlay)
        {
            spawner.autoPlay = false;
            autoplayButton.GetComponent<Text>().text = "Autoplay: Off";
        }
        else
        {
            spawner.autoPlay = true;
            autoplayButton.GetComponent<Text>().text = "Autoplay: On";
        }
    }

    public void playRound()
    {
        if (!spawner.roundInProgress)
        {
            spawner.canSpawn = true;
            spawner.roundInProgress = true;
        }
    }
}
