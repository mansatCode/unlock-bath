using UnityEngine;

public class CodeLockDoorController : MonoBehaviour
{
    [SerializeField] GameObject codePanel;
    public static bool isLocked = true;

    public bool isOpen;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public Sprite open, closed;

    private bool inRange, panelActive;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        isOpen = false;
        panelActive = false;
        inRange = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("69");
            inRange = true;
        }
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (panelActive)
                {
                    codePanel.SetActive(false);

                }
                else
                {
                    codePanel.SetActive(true);
                }
                panelActive = !panelActive;
            }
        }

        if (!isLocked)
        {
            OpenDoor();
        }
    }

    /*
     * if (other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("Player entered code door range");
            if (CodePanel.codePanelActive)
            {
                codePanel.SetActive(true);
            }
        }

    if (other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("Player left code door range");
            codePanel.SetActive(false);
        }
     */

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
        codePanel.SetActive(false);
        panelActive = false;
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = open;
        isOpen = true;
        boxCollider.enabled = false;
    }
}
