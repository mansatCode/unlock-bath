using UnityEngine;

public class LockDoorController : MonoBehaviour
{
    public GameObject keyRequired;
    public GameObject keyPrefab;

    public Signal context;

    private Inventory inventory;
    private bool isInRange;

    private void OnTriggerExit2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player") && !collision.isTrigger && GameObject.FindGameObjectWithTag("MainHallLockedDoor").GetComponent<DoorController>().isLocked == true)
        {
            context.Raise();
            isInRange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameObject.FindGameObjectWithTag("MainHallLockedDoor").GetComponent<DoorController>().isLocked == true)
        {
            context.Raise();
            isInRange = true;
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) &&
            GameObject.FindGameObjectWithTag("MainHallLockedDoor").GetComponent<DoorController>().isLocked == true)
        {
            GameObject[] itemButtons = inventory.itemButtons;

            for (int i = 0; i < itemButtons.Length; i++)
            {
                try
                {
                    if (itemButtons[i].GetComponent<isKey>().key)
                    {
                        
                        GameObject.FindGameObjectWithTag("MainHallLockedDoor").GetComponent<DoorController>().isLocked = false;
                        GameObject.FindGameObjectWithTag("MainHallLockedDoor").GetComponent<DoorController>().OpenDoor();
                        //removeKey(itemButtons[i], i);
                        context.Raise();
                    }
                }
                catch
                {
                    Debug.Log("No key");
                }
            }

        }
    }

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void removeKey(GameObject keySlot, int index)
    {
        inventory.isFull[index] = false;
        inventory.slots[index] = null;
        //Destroy(keySlot);
        //keySlot = null;
        inventory.clearInventory();
    }
}
