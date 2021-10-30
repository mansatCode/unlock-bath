using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagColourController : MonoBehaviour
{
    public bool bagToggled = true;

    public void toggleBag()
    {
        if (bagToggled)
        {
            gameObject.GetComponent<Image>().color = Color.gray;
        } else
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
        bagToggled = !bagToggled;

    }
}
