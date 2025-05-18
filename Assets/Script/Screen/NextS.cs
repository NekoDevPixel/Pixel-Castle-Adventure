using UnityEngine;
using UnityEngine.SceneManagement;

public class NextS : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickStart()
    {
        // Load the next scene
        SceneManager.LoadScene("InGame");
    }
    
    public void OnClickExit()
    {
        // Exit the application
        Application.Quit();
    }
}
