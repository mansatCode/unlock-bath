using UnityEngine;

public class LockDoorController : MonoBehaviour
{
    public GameObject keyRequired;
    public GameObject keyPrefab;

    private Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            GameObject[] itemButtons = inventory.itemButtons;

            for (int i = 0; i < itemButtons.Length; i++) 
            {
                try
                {
                    if (itemButtons[i].GetComponent<isKey>().key)
                    {
                        GameObject.FindGameObjectWithTag("MainHallLockedDoor").GetComponent<DoorController>().isLocked = false;
                        removeKey(itemButtons[i], i);
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
        Destroy(keySlot);
        keySlot = null;
    }
}
