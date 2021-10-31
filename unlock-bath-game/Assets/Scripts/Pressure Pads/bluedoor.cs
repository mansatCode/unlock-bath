using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluedoor : MonoBehaviour
{
    public Signal context;
    private bool closeSignal = false;

    public string tag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTERED ");
            if (GameObject.FindGameObjectWithTag(tag).GetComponent<DoorController>().isLocked)
            {
                context.Raise();

                if (GameObject.FindGameObjectWithTag("Player").GetComponent<GroundFloorKeyCheck>().keyOneObtained)
                {
                    GameObject.FindGameObjectWithTag(tag).GetComponent<DoorController>().isLocked = false;
                    closeSignal = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && GameObject.FindGameObjectWithTag(tag).GetComponent<DoorController>().isLocked == true)
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
