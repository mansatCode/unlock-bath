using UnityEngine;

public class PadsDetector : MonoBehaviour
{
    public bool[] PadActive;
    public GameObject[][] Pillars;
    public static PadsDetector Instance;

    private void Start()
    {

        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        PadActive = new bool[3];
        GameObject[] SmallPillars = GameObject.FindGameObjectsWithTag("Pillar 1");
        GameObject[] MediumPillars = GameObject.FindGameObjectsWithTag("Pillar 2");
        GameObject[] LargePillars = GameObject.FindGameObjectsWithTag("Pillar 3");
        Pillars = new GameObject[][] {SmallPillars, MediumPillars, LargePillars};

    }

    public void AddActive()
    {
        Debug.Log("AddActive called");
        for (int i = 0; i < PadActive.Length; i++)
        {
            Debug.Log(PadActive[i]);
            if (!PadActive[i])
            {
                PadActive[i] = true;
                TurnOnPillars(i);
                Debug.Log("Pillars activated");
                CheckUnlocked();
                return;
            }
        }

        
    }

    public void CheckUnlocked()
    {
        foreach (bool active in PadActive)
        {
            if (!active)
            {
                return;
            }
        }

        //If all pads are active, unlock door
        bool DoorLocked = GameObject.FindGameObjectWithTag("Locked Door").GetComponent<DoorController>().isLocked;
        if (DoorLocked)
        {
            GameObject.FindGameObjectWithTag("Locked Door").GetComponent<DoorController>().isLocked = false;
            GameObject.FindGameObjectWithTag("Locked Door").GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void RemoveActive()
    {
        Debug.Log("Remove Active called");
        for (int i = 2; i >= 0; i--)
        {
            if (PadActive[i])
            {
                PadActive[i] = false;
                TurnOffPillars(i);
                Debug.Log($"{PadActive[i]}");
                
                return;
            }
        }

    }

    private void TurnOnPillars(int i)
    {
        GameObject[] PillarsToEnable = Pillars[i];
        foreach (GameObject p in PillarsToEnable)
        {
            p.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void TurnOffPillars(int i)
    {
        GameObject[] PillarsToEnable = Pillars[i];
        foreach (GameObject p in PillarsToEnable)
        {
            p.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
