using UnityEngine;

public class CodeLockDoorController : MonoBehaviour
{
    [SerializeField] GameObject codePanel;
    public static bool isLocked = true;

    public bool isOpen;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public Sprite open, closed;
    public Signal context;

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
            inRange = true;
        }

        if (isLocked && inRange)
        {
            context.Raise();
        }
    }

    private void Update()
    {
        if (inRange && isLocked)
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

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
        codePanel.SetActive(false);
        panelActive = false;

        if(isLocked)
        {
            context.Raise();
        }
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = open;
        isOpen = true;
        boxCollider.enabled = false;
    }
}
