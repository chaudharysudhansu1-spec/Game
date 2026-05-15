using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            // Reload the current scene to restart the game
            SceneManager.LoadScene("GameScene");
        }
        // Optionally, you can also check for the "Enter" key on the numeric keypad
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // Reload the current scene to restart the game
            SceneManager.LoadScene("GameScene");
        }
    }
}
