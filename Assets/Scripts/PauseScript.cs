using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject upgradePanel;
    public GameObject resumeButton;
    public PlayerInputHandler inputHandler;

    InputAction pauseAction;

    bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseAction = InputSystem.actions.FindAction("System/Pause");
        pauseAction.Enable();

        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else if (Time.timeScale > 0f && !upgradePanel.activeSelf)
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        isPaused = true;

        Time.timeScale = 0f;

        inputHandler.DisablePlayerInput();

        pausePanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }
    public void ResumeGame()
    {
        isPaused = false;

        pausePanel.SetActive(false);

        inputHandler.EnablePlayerInput();

        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("TitleScene");
    }
}
