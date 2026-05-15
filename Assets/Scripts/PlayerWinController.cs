using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinController : MonoBehaviour
{
    [SerializeField] private string winSceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}
