using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_Spawner_Script : MonoBehaviour
{
    private List<GameObject> bloods = new List<GameObject>();

    public GameObject bloodParticle;

    void Start()
    {
        StartCoroutine(bloodEffect());
        Invoke("destroyBloodAndSelf", 2);
    }

    private void spawnBlood()
    {
        Quaternion spawnrotation = spawnRotation();
        GameObject blood = Instantiate(bloodParticle, transform.position, spawnrotation);
        blood.GetComponent<Rigidbody>().velocity = blood.transform.forward*25;
        bloods.Add(blood);
    }

    private Quaternion spawnRotation()
    {
        float x = Random.Range(-180, 0);
        float y = Random.Range(0, 360);
        return Quaternion.Euler(x, y, 0);
    }

    private void destroyBloodAndSelf()
    {
        foreach (GameObject blood in bloods)
        {
            Destroy(blood);
        }
        Destroy(gameObject);
    }

    private IEnumerator bloodEffect()
    {
        int index = 0;

        while (index < 10)
        {
            spawnBlood();
            index += 1;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
