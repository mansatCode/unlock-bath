using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    private bool hasBeenShown = false;

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasBeenShown)
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            hasBeenShown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
        }
    }
 
}
