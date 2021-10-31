using UnityEngine;

public class ResetBox : MonoBehaviour
{
    private bool inRange;
    private GameObject crate;
    public Vector2 startingPosition;

    private void Start()
    {
        startingPosition = this.gameObject.transform.position;
        crate = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                crate.transform.position = startingPosition;
            }
        }
    }
}
