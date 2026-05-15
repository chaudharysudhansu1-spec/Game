using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
