using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    public Text codeText;
    public static bool codePanelActive = true;
    public Signal context;

    [SerializeField] GameObject codePanel;

    
    private string codeTextValue = "";

    private void Start()
    {
        codePanel.SetActive(false);
    }

    private void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "BMM")
        {
            Debug.Log("correct code entered");
            CodeLockDoorController.isLocked = false;
            codePanelActive = false;
            codePanel.SetActive(false);
            context.Raise();
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }
    }

    public void AddChar(string character)
    {
        codeTextValue += character;
    }
}
