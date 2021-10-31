using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Inventory inventory;
    private bool keyObtained;

    public bool isOpen;
    public SpriteRenderer spriteRenderer;
    public Sprite open, closed;
    public GameObject itemButton;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        isOpen = false;
        keyObtained = false;
    }
    public void OpenChest()
    {
        if (!isOpen)
        {
            spriteRenderer.sprite = open;
            isOpen = true;
        } 
        else
        {
            spriteRenderer.sprite = closed;
            isOpen = false;
        }
    }

    public void GiveKey()
    {
        if (!keyObtained)
        {
            keyObtained = true;
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //Add item to inv
                    inventory.isFull[i] = true;
                    GameObject itemButtonObject = Instantiate(itemButton, inventory.slots[i].transform, false);
                    itemButtonObject.AddComponent<isKey>();
                    itemButtonObject.GetComponent<isKey>().key2 = true;


                    inventory.itemButtons[i] = itemButtonObject;

                    //Hides button if bag is not toggled

                    if (!inventory.invToggled)
                    {
                        itemButtonObject.SetActive(false);
                    }
                    break;
                }
            }
        }
    }
}
