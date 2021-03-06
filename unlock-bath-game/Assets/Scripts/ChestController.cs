using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public SpriteRenderer spriteRenderer;
    public Sprite open, closed;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        isOpen = false;
    }
    public void OpenChest()
    {
        if (!isOpen)
        {
            spriteRenderer.sprite = open;
            isOpen = true;
        } 
        else
        {
            spriteRenderer.sprite = closed;
            isOpen = false;
        }
    }
}
