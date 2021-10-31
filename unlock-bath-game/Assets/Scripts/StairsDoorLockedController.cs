using UnityEngine;

public class StairsDoorLockedController : MonoBehaviour
{
    public GameObject keyRequired;
    public GameObject keyPrefab;

    public Signal context;

    private Inventory inventory;
    private bool isInRange;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && GameObject.FindGameObjectWithTag("StairsLockedDoor").GetComponent<DoorController>().isLocked == true)
        {
            context.Raise();
            isInRange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameObject.FindGameObjectWithTag("StairsLockedDoor").GetComponent<DoorController>().isLocked == true)
        {
            context.Raise();
            isInRange = true;
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) &&
            GameObject.FindGameObjectWithTag("StairsLockedDoor").GetComponent<DoorController>().isLocked == true)
        {
            GameObject[] itemButtons = inventory.itemButtons;

            for (int i = 0; i < itemButtons.Length; i++)
            {
                try
                {
                    if (itemButtons[i].GetComponent<isKey>().key2)
                    {
                        if (GameObject.FindGameObjectWithTag("StairsLockedDoor").GetComponent<DoorController>().isLocked == false)
                        {
                            return;
                        }
                        Debug.Log("Key2 found");
                        GameObject.FindGameObjectWithTag("StairsLockedDoor").GetComponent<DoorController>().isLocked = false;     
                        context.Raise();
                        return;
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
}
