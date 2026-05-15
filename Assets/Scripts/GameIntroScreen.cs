using UnityEngine;
using UnityEngine.UI;

public class GameIntroScreen : MonoBehaviour
{
    [SerializeField] private Canvas introCanvas; 
    [SerializeField] private Button enterButton; 
    
    private bool gameStarted = false;

    void Start()
    {
        Time.timeScale = 0f;

        if (introCanvas != null)
        {
            introCanvas.gameObject.SetActive(true);
        }

        if (enterButton != null)
        {
            enterButton.onClick.AddListener(OnEnterButtonClicked);
        }
    }

    void Update()
    {
        if (!gameStarted && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            OnEnterButtonClicked();
        }
    }

    void OnEnterButtonClicked()
    {
        if (gameStarted) return; 
        
        gameStarted = true;

        Time.timeScale = 1f;

        if (introCanvas != null)
        {
            introCanvas.gameObject.SetActive(false);
        }

    }
}

