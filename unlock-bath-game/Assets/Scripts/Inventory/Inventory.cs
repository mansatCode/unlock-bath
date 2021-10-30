using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots, itemButtons;
    public bool invToggled;

    private void Start()
    {
        itemButtons = new GameObject[3];
    }

}


