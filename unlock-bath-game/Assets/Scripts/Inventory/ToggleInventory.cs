using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInventory : MonoBehaviour
{
    public bool invEnabled;
    public GameObject slot;
    public Image image;
    private Inventory inventory;
    
    void Start()
    {
        invEnabled = false;
        image = slot.GetComponent<Image>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void toggleVisibility()
    {
        slot.GetComponent<Image>().enabled = !invEnabled;
        toggleItemButtons(invEnabled);
        image.enabled = !invEnabled;
        invEnabled = !invEnabled;
    }

    private void toggleItemButtons(bool invEnabled)
    {
        foreach (GameObject itemButton in inventory.itemButtons)
        {
            if (itemButton != null)
            {
                itemButton.SetActive(!invEnabled);
            }
        }
    }
}
