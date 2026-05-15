using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] carPrefabs; 
    [SerializeField] private float spawnDelay = 2f; 
    [SerializeField] private float spawnInterval = 3f; 
    
    private float _spawnTimer;
    private int _carCount = 0;

    void Start()
    {
        _spawnTimer = spawnDelay; 
    }

    void Update()
    {
        if (PlayerCollision.isInSafeZone)
        {
            return;
        }
        
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0f)
        {
            SpawnCar();
            _spawnTimer = spawnInterval; 
        }
    }

    void SpawnCar()
    {
        if (carPrefabs != null && carPrefabs.Length > 0)
        {
            GameObject randomPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];
            
            if (randomPrefab != null)
            {
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
