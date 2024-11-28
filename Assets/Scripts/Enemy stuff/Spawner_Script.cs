using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Script : MonoBehaviour
{
    public Logic_Script logic;

    public List<GameObject> enemies;
    public bool finalRound = false;
    public bool lastEnemySpawned = false;
    public bool roundInProgress = false;
    public bool canSpawn = false;
    public bool autoPlay = false;
    private int currentRound = 0;
    private Vector3 position;

    public delegate IEnumerator functionDelegate();
    private List<functionDelegate> functionList = new List<functionDelegate>();

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic_Script>();

        position = transform.position + new Vector3(15,0,0);

        functionList.Add(roundOne);
        functionList.Add(roundTwo);
        functionList.Add(roundThree);
    }

    private void Update()
    {
        hasRoundFinished();

        if (canSpawn)
        {
            try // runs the rounds until there are no more
            {
                StartCoroutine(functionList[currentRound]());
                canSpawn = false;
            }
            catch // this runs when the final round is beat
            {
                Menu_Manager_Script.instance.openWinMenu();
                canSpawn = false;
            }
        }
    }

    private void spawnEnemy(GameObject enemy) // spawns in a new enemy at the start point
    {
        GameObject bloon = Instantiate(enemy, position, transform.rotation);
        logic.activeEnemies.Add(bloon);

        if (bloon.GetComponent<Stats_Script>().isJetpacked)
        {
            bloon.transform.position = position + new Vector3(0,10,0);
        }
    }

    // this function checks if the round is over (all enemies are dead)
    // if autoplay is on it starts the next round, else it sets up ready for the next round
    private void hasRoundFinished()
    {
        if (logic.activeEnemies.Count == 0 && !autoPlay && lastEnemySpawned) // using lastEnemySpawned stops errors caused by script execution order
        {
            currentRound += 1;
            roundInProgress = false;
            lastEnemySpawned = false;

            if (finalRound)
            {
                canSpawn = true;
            }
        }
        else if (logic.activeEnemies.Count == 0 && autoPlay && lastEnemySpawned)
        {
            currentRound += 1;
            canSpawn = true;
            lastEnemySpawned = false;
        }
    }

    // spawns the 'enemy', every 'spawnRate' seconds, until 'spawnAmount' have been spawned.
    // isLast lets the script know if this is the last set of spawns for a given round.
    private IEnumerator spawnEnemies(GameObject enemy, int spawnRate, int spawnAmount, bool isLast)
    {
        int index = 0;
        while (true)
        {
            if (index < spawnAmount)
            {
                spawnEnemy(enemy);
                index += 1;
                yield return new WaitForSeconds(spawnRate);
            }
            else
            {
                break;
            }
        }

        if (isLast)
        {
            lastEnemySpawned = true;
        }
    }

    private IEnumerator roundOne()
    {
        StartCoroutine(spawnEnemies(enemies[0], 1, 10, false));
        yield return new WaitForSeconds(10);
        StartCoroutine(spawnEnemies(enemies[1], 1, 10, false));
        yield return new WaitForSeconds(10);
        StartCoroutine(spawnEnemies(enemies[2], 1, 5, true));
    }

    private IEnumerator roundTwo()
    {
        StartCoroutine(spawnEnemies(enemies[3], 1, 10, false));
        yield return new WaitForSeconds(10);
        StartCoroutine(spawnEnemies(enemies[4], 1, 10, false));
        yield return new WaitForSeconds(10);
        StartCoroutine(spawnEnemies(enemies[5], 1, 5, true));
    }

    private IEnumerator roundThree()
    {
        finalRound = true;
        StartCoroutine(spawnEnemies(enemies[6], 1, 10, false));
        yield return new WaitForSeconds(10);
        StartCoroutine(spawnEnemies(enemies[7], 1, 10, false));
        yield return new WaitForSeconds(10);
        StartCoroutine(spawnEnemies(enemies[8], 1, 5, true));
    }
}
