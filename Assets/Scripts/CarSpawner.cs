using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] carPrefabs; 
    [SerializeField] private float spawnDelay = 2f; 
    [SerializeField] private float spawnInterval = 3f; // How often to spawn cars
    
    private float _spawnTimer;
    private int _carCount = 0;

    void Start()
    {
        _spawnTimer = spawnDelay; // Wait before first spawn
    }

    void Update()
    {
        // Don't spawn cars if player is in SafeZone
        if (PlayerCollision.isInSafeZone)
        {
            return;
        }
        
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0f)
        {
            SpawnCar();
            _spawnTimer = spawnInterval; // Reset timer for next spawn
        }
    }

    void SpawnCar()
    {
        if (carPrefabs != null && carPrefabs.Length > 0)
        {
            // Pick a random prefab from the array
            GameObject randomPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];
            
            if (randomPrefab != null)
            {
                // Spawn car at this spawner's position
                GameObject newCar = Instantiate(randomPrefab, transform.position, Quaternion.identity);
                _carCount++;

                Debug.Log($"Car spawned! Total cars: {_carCount}");
            }
        }
        else
        {
            Debug.LogError("Car prefabs array is empty or not assigned!");
        }
    }

    private System.Collections.IEnumerator TrackCarDestruction(GameObject car)
    {
        while (car != null)
        {
            yield return null;
        }
        _carCount--;
    }
}
