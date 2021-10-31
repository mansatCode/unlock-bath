using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckup : MonoBehaviour
{
    private Inventory inventory;
    private BagColourController bag;
    public GameObject itemButton, key;


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
                    if (itemButton == key)
                    {
                        itemButtonObject.AddComponent<isKey>();
                        itemButtonObject.GetComponent<isKey>().key = true;
                    }
                    inventory.itemButtons[i] = itemButtonObject;
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
