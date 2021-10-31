using UnityEngine;

public class GoldenKeyPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PICK UP GOLDEN KEY");
            GameObject.FindGameObjectWithTag("Player").GetComponent<GroundFloorKeyCheck>().keyTwoObtained = true;
        }
    }
}
