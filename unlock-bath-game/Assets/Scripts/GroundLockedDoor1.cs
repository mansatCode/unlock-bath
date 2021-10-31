using UnityEngine;

public class GroundLockedDoor1 : MonoBehaviour
{
    private bool keyFound = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTERED ");
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<GroundFloorKeyCheck>().keyOneObtained)
            {
                GameObject.FindGameObjectWithTag("GroundDoorLocked1").GetComponent<DoorController>().isLocked = false;
            }
        }
    }
}
