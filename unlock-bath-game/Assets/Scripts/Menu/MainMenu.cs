using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("FirstFloor");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
