using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public Inventory inventory;
    public bool invSaved = false;

    public void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetInventory()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        invSaved = true;
    }
}
