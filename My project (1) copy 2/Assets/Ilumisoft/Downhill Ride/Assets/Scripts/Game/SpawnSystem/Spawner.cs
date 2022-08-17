using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnSystem spawnSystem = null;

    [SerializeField] private BoxCollider spawnArea = null;
    
    [SerializeField, Tooltip("Start number of spawns per second")] 
    private int startFrequency = 2;

    [SerializeField, Tooltip("Max number of spawns per second")] 
    private int maxFrequency = 10;
    
    [SerializeField, Tooltip("Increase rate per second")] 
    private float increaseRate = 0.2f;

    private float _spawnFrequency = 1.0f;

    private void Awake()
    {
        if (spawnSystem == null)
        {
            Debug.LogError("Spawn system is a required field, but not set in the inspector", this);
        }
    }

    private void Start()
    {
        _spawnFrequency = startFrequency;
        StartCoroutine(SpawnCoroutine());
    }

    private void Update()
    {
        _spawnFrequency += increaseRate*Time.deltaTime;
        _spawnFrequency = Mathf.Clamp(_spawnFrequency, startFrequency, maxFrequency);
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {

            float spawnInterval = 1.0f / this._spawnFrequency;

            spawnSystem.Spawn(GetSpawnPosition());

            yield return new WaitForSeconds(spawnInterval);

        }
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition = transform.position;

        var bounds = spawnArea.bounds;
        
        spawnPosition.x = Random.Range(bounds.min.x, bounds.max.x);

        return spawnPosition;
    }
}
