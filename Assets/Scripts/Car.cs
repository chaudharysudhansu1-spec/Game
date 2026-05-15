using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 10f; 
    [SerializeField] private string sceneToLoad = "GameOver"; 
    [SerializeField] private float carDetectionDistance = 3f; 
    
    private bool isStoppedByCarAhead = false;
    private bool isStoppedBySafeZone = false;
    [SerializeField] private GameObject rayObj;

    void Start()
    {
        
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
                    
                    return;
                }
        }        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
