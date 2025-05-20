using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenuUI;
    public AudioSource BackgroundMusic;

    void Start()
    {
        inGameMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if the in-game menu is already active
            if (inGameMenuUI.activeSelf)
            {
                ContinueGame();
            }
            else
            {
                ToggleInGameMenu();
            }
        }
    }

    public void ToggleInGameMenu()
    {
        inGameMenuUI.SetActive(!inGameMenuUI.activeSelf);
        BackgroundMusic.mute = inGameMenuUI.activeSelf; // Mute background music when menu is active
        Time.timeScale = inGameMenuUI.activeSelf ? 0 : 1; // Pause the game when menu is active
    }

    public void ContinueGame()
    {
        inGameMenuUI.SetActive(false);
        BackgroundMusic.mute = false; // Unmute background music when resuming
        Time.timeScale = 1; // Resume the game
    }   

    public void ExitMainMenu()
    {
        Time.timeScale = 1; // Reset timeScale before changing scenes
        SceneManager.LoadScene("MenuScreen");
    }
}
