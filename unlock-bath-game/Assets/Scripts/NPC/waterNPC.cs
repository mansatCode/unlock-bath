using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterNPC : MonoBehaviour
{
    public GameObject dialogBox, keyToGive;
    public Text dialogText;
    private Inventory inventory;

    private string line1;
    private string line2;
    private string outro1;
    private string outro2;

    private int activeDialog;
    public bool playerInRange;

    public bool WaterGiven;
    public int waterSlot;
    public bool keyGiven;
    public bool waterTaken;

    private void Start()
    {
        WaterGiven = false;
        keyGiven = false;
        line1 = "My Rheumatism has been flaring up lately. I could really do with another vial of the apothecary's medicine.";
        line2 = "If you can get some for me, I can give you this old key I found lying around.";
        outro1 = "Oh wow thank you. As promised, heres your key.";
        outro2 = "Thanks again, real life-saver.";
        activeDialog = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            checkForWater();

            if (WaterGiven == false)
            {
                displayIntro();
            } else
            {
                displayOutro();
            }
        }
    }

    private void checkForWater()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        GameObject[] itemButtons = inventory.itemButtons;
        if (waterTaken)
        {
            WaterGiven = true;
            inventory.itemButtons[waterSlot].GetComponent<Image>().color = Color.gray;
            inventory.slots[waterSlot].GetComponent<Image>().color = Color.gray;

        }
    }

    private void displayIntro()
    {
        switch (activeDialog)
        {
            case 0:
                dialogBox.SetActive(true);
                dialogText.text = line1;
                activeDialog = 1;
                break;
            case 1:
                dialogText.text = line2;
                activeDialog = 2;
                break;
            case 2:
                dialogBox.SetActive(false);
                activeDialog = 0;
                break;
            default:
                dialogBox.SetActive(false);
                activeDialog = 0;
                break;
        }
    }

    private void displayOutro()
    {
        if (!keyGiven)
        {
            if (!dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
                dialogText.text = outro1;
                giveKey();
                keyGiven = true;
            }
            else
            {
                dialogBox.SetActive(false);
            }
            
        }
        else
        {
            if (!dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
                dialogText.text = outro2;
            }
            else
            {
                dialogBox.SetActive(false);
            }
        }
    }

    private void giveKey()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                //Add item to inv
                inventory.isFull[i] = true;
                GameObject itemButtonObject = Instantiate(keyToGive, inventory.slots[i].transform, false);
                inventory.itemButtons[i] = itemButtonObject;

                itemButtonObject.AddComponent<isKey>();
                itemButtonObject.GetComponent<isKey>().key = true;

                //Hides button if bag is not toggled

                if (!inventory.invToggled)
                {
                    itemButtonObject.SetActive(false);
                }
                break;
            }
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }


}
