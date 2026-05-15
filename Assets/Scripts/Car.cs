using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 10f; // Destroys the car after 10 seconds to save memory
    [SerializeField] private string sceneToLoad = "GameOver"; // Scene to load on collision
    [SerializeField] private float carDetectionDistance = 3f; // Distance to detect cars ahead
    
    private bool isStoppedByCarAhead = false;
    private bool isStoppedBySafeZone = false;
    [SerializeField] private GameObject rayObj;

    void Start()
    {
        // Automatically destroy the car after a few seconds so they don't pile up off-screen
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        DetectCarAhead();
        DetectSafeZoneAhead();
        Move();
    }

    void DetectCarAhead()
    {
        // Raycast forward to detect other cars ahead
        RaycastHit hit;
        Vector3 rayDirection = transform.forward;

        if (Physics.Raycast(rayObj.transform.position, rayDirection, out hit, carDetectionDistance))
        {
            if (hit.collider.CompareTag("Car"))
            {
                isStoppedByCarAhead = true;
                Debug.DrawRay(rayObj.transform.position, rayDirection * hit.distance, Color.yellow);
            }
            else
            {
                isStoppedByCarAhead = false;
            }
        }
        else
        {
            isStoppedByCarAhead = false;
            Debug.DrawRay(rayObj.transform.position, rayDirection * carDetectionDistance, Color.cyan);
        }
    }

    void DetectSafeZoneAhead()
    {
        // Raycast forward to detect SafeZone ahead
        RaycastHit hit;
        Vector3 rayDirection = transform.forward;

        if (Physics.Raycast(transform.position, rayDirection, out hit, carDetectionDistance * 1.5f))
        {
            if (hit.collider.CompareTag("SafeZone"))
            {
                isStoppedBySafeZone = true;
                Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.red);
            }
            else
            {
                isStoppedBySafeZone = false;
            }
        }
        else
        {
            isStoppedBySafeZone = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Car hit the player! Loading scene...");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void Move()
    {
        if(PlayerCollision.isInSafeZone){
            if (isStoppedByCarAhead || isStoppedBySafeZone)
                {
                    // Don't move
                    return;
                }
        }        // Stop if there's a car ahead, SafeZone ahead, or player is in SafeZone
        

        // Move the car forward continuously
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
