using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    public Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        // Load the next scene or start the game
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
