using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Signal context;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool isPlayerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("Player in range");
            isPlayerInRange = true;
            context.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            Debug.Log("Player left range");
            isPlayerInRange = false;
            dialogBox.SetActive(false);
        }
    }

    public void ToggleSign()
    {
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }
        else
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
    }
}
