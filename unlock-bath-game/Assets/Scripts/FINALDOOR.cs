using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINALDOOR : MonoBehaviour
{
    private bool key2Found = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTERED ");
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<GroundFloorKeyCheck>().keyTwoObtained)
            {
                Debug.Log("Key 2 obtained?");
                GameObject.FindGameObjectWithTag("FinalLockedDoor").GetComponent<DoorController>().isLocked = false;
            }
        }
    }


}
