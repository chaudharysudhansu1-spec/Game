using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private Car carScript; 
    
    public static bool isInSafeZone = false; 
    
    void Update()
    {
        // Raycast downward from the player's position
        RaycastHit hit;
        Vector3 rayDirection = Vector3.down;
        
        // Include trigger colliders in the raycast
        if (Physics.Raycast(transform.position, rayDirection, out hit, rayDistance, -1))
        {
            // Check if the raycast hit an object with the SafeZone tag
            if (hit.collider.CompareTag("SafeZone"))
            {
                isInSafeZone = true;
                Debug.Log("Raycast hit SafeZone!");
                Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.green);
            }
            else
            {
                isInSafeZone = false;
                Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.red);
            }
        }
        else
        {
            isInSafeZone = false;
            // Draw the full ray if nothing was hit
            Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.yellow);
        }
    }
}
