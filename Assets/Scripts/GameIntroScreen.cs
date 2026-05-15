using UnityEngine;
using UnityEngine.UI;

public class GameIntroScreen : MonoBehaviour
{
    [SerializeField] private Canvas introCanvas; 
    [SerializeField] private Button enterButton; 
    
    private bool gameStarted = false;

    void Start()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Make sure canvas is visible
        if (introCanvas != null)
        {
            introCanvas.gameObject.SetActive(true);
        }

        // Add button listener
        if (enterButton != null)
        {
            enterButton.onClick.AddListener(OnEnterButtonClicked);
        }
    }

    void Update()
    {
        // Check for Enter key press while paused (Input works even when Time.timeScale = 0)
        if (!gameStarted && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            OnEnterButtonClicked();
        }
    }

    void OnEnterButtonClicked()
    {
        if (gameStarted) return; // Prevent multiple calls
        
        gameStarted = true;

        // Unpause the game
        Time.timeScale = 1f;

        // Hide the intro canvas
        if (introCanvas != null)
        {
            introCanvas.gameObject.SetActive(false);
        }

    }
}

