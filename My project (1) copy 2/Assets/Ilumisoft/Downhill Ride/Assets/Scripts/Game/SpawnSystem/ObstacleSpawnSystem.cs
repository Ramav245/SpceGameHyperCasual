using UnityEngine;

public class ObstacleSpawnSystem : SpawnSystem
{
    [SerializeField] private GameObject prefab = null;
    
    [SerializeField] private int poolSize = 20;
    
    //The pool holding all spawnable objects
    private GameObject[] _pool;

    //The index of the next object spawned
    private int _index;

    private void Awake()
    {
        _pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            var instance = Instantiate(prefab);
            
            instance.SetActive(false);
            
            _pool[i] = instance;
        }
        _index = 0;
    }
    
    public override void Spawn(Vector3 position)
    {
        var instance = _pool[_index];

        instance.transform.position = position;
        
        instance.SetActive(true);

        _index++;

        if (_index >= _pool.Length)
        {
            _index = 0;
        }
    }
}
