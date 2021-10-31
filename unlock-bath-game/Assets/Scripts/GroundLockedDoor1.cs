using UnityEngine;

public class GroundLockedDoor1 : MonoBehaviour
{
    private bool keyFound = false;
    private bool closeSignal = false;
    public Signal context;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTERED ");
            if (GameObject.FindGameObjectWithTag("GroundDoorLocked1").GetComponent<DoorController>().isLocked)
            {
                context.Raise();

                if (GameObject.FindGameObjectWithTag("Player").GetComponent<GroundFloorKeyCheck>().keyOneObtained)
                {
                    GameObject.FindGameObjectWithTag("GroundDoorLocked1").GetComponent<DoorController>().isLocked = false;
                    closeSignal = true;
                }
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && GameObject.FindGameObjectWithTag("GroundDoorLocked1").GetComponent<DoorController>().isLocked == true)
        {
            context.Raise();
        }
    }

    private void Update()
    {
        if (closeSignal)
        {
            context.Raise();
            closeSignal = false;
        }
    }
}
