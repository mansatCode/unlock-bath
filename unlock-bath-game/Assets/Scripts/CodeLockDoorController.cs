using UnityEngine;

public class CodeLockDoorController : MonoBehaviour
{
    [SerializeField] GameObject codePanel;
    public static bool isLocked = true;

    public bool isOpen, isInRange;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public Sprite open, closed;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        isOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("Player entered code door range");
            if (CodePanel.codePanelActive)
            {
                codePanel.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (!isLocked)
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("Player left code door range");
            codePanel.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = open;
        isOpen = true;
        boxCollider.enabled = false;
    }
}
