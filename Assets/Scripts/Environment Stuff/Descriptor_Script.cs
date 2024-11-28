using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Descriptor_Script : MonoBehaviour
{
    public GameObject descriptor;

    public void test1()
    {
        descriptor.SetActive(true);
    }
    public void test2()
    {
        descriptor.SetActive(false);
    }
}
