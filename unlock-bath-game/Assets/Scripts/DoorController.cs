using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen, isInRange, isLocked;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public Sprite open, closed;


    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        isOpen = false;
    }
    public void OpenDoor()
    {
        if (!isLocked)
        {
            if (!isOpen && !isInRange)
            {

                spriteRenderer.sprite = open;
                isOpen = true;
                boxCollider.enabled = false;
            }
            else if (isOpen && !isInRange)
            {
                spriteRenderer.sprite = closed;
                isOpen = false;
                boxCollider.enabled = true;
            }
        }
    }
}
