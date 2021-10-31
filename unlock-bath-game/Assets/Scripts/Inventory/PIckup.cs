using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckup : MonoBehaviour
{
    private Inventory inventory;
    private BagColourController bag;
    public GameObject itemButton;
    public bool key, potion;


    private void Start()
    { 
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        bag = GameObject.FindGameObjectWithTag("Bag").GetComponent<BagColourController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //Add item to inv
                    inventory.isFull[i] = true;
                    GameObject itemButtonObject = Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.itemButtons[i] = itemButtonObject;

                    itemButtonObject.AddComponent<isKey>();
                    if (key)
                    {
                        itemButtonObject.GetComponent<isKey>().key = true;
                    } else if (potion)
                    {
                        itemButtonObject.GetComponent<isKey>().potion = true;
                        GameObject.FindGameObjectWithTag("WaterNPC").GetComponent<waterNPC>().waterTaken = true;
                        GameObject.FindGameObjectWithTag("WaterNPC").GetComponent<waterNPC>().waterSlot = i;
                    }
                    
                    
                    Destroy(gameObject);

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
