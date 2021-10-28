using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInventory : MonoBehaviour
{
    public bool invEnabled;
    public GameObject slot;
    public Image image;
    
    void Start()
    {
        invEnabled = false;
        image = slot.GetComponent<Image>();
    }

    public void toggleVisibility()
    {
        if (invEnabled)
        {
            image.enabled = false; 
            invEnabled = false;
        }
        else
        {
            slot.GetComponent<Image>().enabled = true;
            image.enabled = true;
            invEnabled = true;
        }
    }
}
