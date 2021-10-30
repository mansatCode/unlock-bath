using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    { 
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
